using System.Collections;
using System.Collections.Generic;
using Jackal;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] private GridController grid;
    [SerializeField] private Bench bench;
    [SerializeField] private ShipController shipController;
    [SerializeField] private UIController uiController;

    [SerializeField] private float boardingXOffsetRange = 5f;
    [SerializeField] private Transform boardAnchor;
    [SerializeField] private Transform shipAnchor;
    public GameState GameState => gameState;
    public int ColorShift { get; private set; } = 0;
    public Bench Bench => bench;
    public ShipController ShipController => shipController;
    private int currentLevel = 0;
    private GameState gameState = GameState.Paused;
    private LevelData levelData;
    private float currentTime;
    private Coroutine timerCoroutine;

    private void Awake()
    {
        shipController.OnShipDocked += NewShipDocked;
        shipController.OnShipDeparted += ShipDeparted;
        ColorShift = Random.Range(0, 20);
        shipController.ColorShift = ColorShift;
        grid.ColorShift = ColorShift;
    }

    private void Start()
    {
        currentLevel = Game.Manager.CurrentLevel;
        LoadLevel(currentLevel);
    }

    public void LoadLevel(int levelNumber)
    {
        TextAsset levelFile = Resources.Load<TextAsset>($"Levels/level_{levelNumber}");
        if (levelFile == null)
        {
            Debug.LogError($"Level {levelNumber} file not found in Resources/Levels folder");
            return;
        }
        levelData = JsonUtility.FromJson<LevelData>(levelFile.text);
        currentTime = levelData.timeLimit;
        uiController.SetLevelText(levelNumber);
        uiController.SetTimerText(currentTime);
        grid.InitializeGrid(levelData, this);
        shipController.InitializeShipSpawner(levelData);
        bench.InitializeSlots(levelData.benchSlots);
    }

    private IEnumerator TimerCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        while (currentTime > 0 && GameState == GameState.Playing)
        {
            yield return wait;
            currentTime--;
            uiController.SetTimerText(currentTime);

            if (currentTime <= 0)
            {
                LevelFailed();
            }
        }
    }

    public void StartTimer()
    {
        StopTimer();
        timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    private void NewShipDocked(Ship ship)
    {   
        TryBoardBenchPassengers();
        EvaluateLoseCondition();
    }

    public void StartPlaying()
    {
        gameState = GameState.Playing;
        StartTimer();
        uiController.RemoveTapToStart();
    }

    private void ShipDeparted(Ship ship)
    {
        if (ship.Data.arrivalOrder == levelData.busSequence.Length-1)
            LevelWon();
    }

    public void PassengerArrivedToBench(Passenger passenger, BenchSlot slot)
    {
        TryBoardBenchPassengerAtSlot(slot);
        if (bench.IsFull())
            EvaluateLoseCondition();
    }

    private void EvaluateLoseCondition()
    {
        if (!bench.IsFull())
            return;
        Ship dockedShip = shipController.GetDockedShip();
        if (dockedShip == null || dockedShip.IsFull)
            return;
        LevelFailed();
    }

    public BenchSlot TryAssignToBenchSlot(Passenger passenger)
    {
        return bench.AssignPassengerToSlot(passenger);
    }

    public bool TryAssignToShip(Passenger passenger)
    {
        Ship ship = shipController.GetDockedShip();
        if (ship == null || passenger == null || !CheckCanBoardPassenger(passenger, ship))
            return false;
        ship.PassengerAssigned();
        return true;

    }

    private void TryBoardBenchPassengers()
    {
        List<BenchSlot> occupiedSlots = bench.GetOccupiedSlots();
        foreach (BenchSlot slot in occupiedSlots)
        {
            if (slot.Passenger == null) continue;
            if (slot.Passenger.IsMoving) continue;
            TryBoardBenchPassengerAtSlot(slot);
        }
    }

    private void TryBoardBenchPassengerAtSlot(BenchSlot slot)
    {
        if (TryAssignToShip(slot.Passenger))
        {
            StartCoroutine(BoardPassenger(slot.Passenger));
            slot.ClearSlot();
        }
    }

    private Transform CreateAnchorOnRadius(Transform baseTransform, float radius, Vector3 passengerPosition)
    {
        Vector3 directionToPlayer = (passengerPosition - baseTransform.position);
        float distanceToPlayer = directionToPlayer.magnitude;
        Vector3 desiredPosition;
        if (distanceToPlayer > radius)
        {
            desiredPosition = baseTransform.position + (directionToPlayer.normalized * radius);
        }
        else
        {
            desiredPosition = passengerPosition;
        }
        GameObject anchor = new GameObject("RadiusAnchor");
        anchor.transform.position = desiredPosition;
        return anchor.transform;
    }

    public IEnumerator BoardPassenger(Passenger passenger)
    {
        Ship ship = shipController.GetDockedShip();
        if (ship == null || passenger == null)
            yield return null;
        Transform tempAnchor = CreateAnchorOnRadius(boardAnchor, boardingXOffsetRange, passenger.transform.position);
        if (tempAnchor.position != passenger.transform.position)
        {
            yield return passenger.MoveTo(tempAnchor, 0.5f);
        }
        Destroy(tempAnchor.gameObject);
        Game.Sound.PlaySound("bloop2");
        yield return passenger.JumpTo(shipAnchor);
        ship.PassengerBoarded();
        bench.ClearSlotForPassenger(passenger);
        Destroy(passenger.gameObject);
        yield return null;
    }

    private bool CheckCanBoardPassenger(Passenger passenger, Ship ship)
    {
        if (!ship.IsFull && passenger.Color == ship.Data.color)
            return true;
        return false;
    }

    private void LevelWon() 
    {
        if (gameState != GameState.Playing) return;
        gameState = GameState.Won;
        Game.Manager.CompleteLevel(currentLevel);
        uiController.LevelWon();
        
        GameDataManager.Instance.playerData.AddDiamond(100);
    }

    public void NextLevel()
    {
           Game.Manager.CompleteLevel(currentLevel);
    }
    
    private void LevelFailed() 
    {
        if (gameState != GameState.Playing) return;
        gameState = GameState.Failed;
        uiController.LevelFailed();
    }
}


//This source code is originally bought from www.codebuysell.com
// Visit www.codebuysell.com
//
//Contact us at:
//
//Email : admin@codebuysell.com
//Whatsapp: +15055090428
//Telegram: t.me/CodeBuySellLLC
//Facebook: https://www.facebook.com/CodeBuySellLLC/
//Skype: https://join.skype.com/invite/wKcWMjVYDNvk
//Twitter: https://x.com/CodeBuySellLLC
//Instagram: https://www.instagram.com/codebuysell/
//Youtube: http://www.youtube.com/@CodeBuySell
//LinkedIn: www.linkedin.com/in/CodeBuySellLLC
//Pinterest: https://www.pinterest.com/CodeBuySell/

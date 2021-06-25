<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "CloudOfDarknessDemo";
var baseOutputPath = $@"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

JsonConvert.DefaultSettings = () =>
{
	return new JsonSerializerSettings
	{
		NullValueHandling = NullValueHandling.Ignore,
		TypeNameHandling = TypeNameHandling.Auto,
		DefaultValueHandling = DefaultValueHandling.Ignore
	};
};

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"CloudOfDarknessMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new WaitForAggro(),
					
					// Beginning Phase
					//*
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					
					
					new StartCastBar { castName = "Ground-razing Particle Beam", duration = 4 },
					new WaitEvent { timeToWait = 4},
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide1" },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new ExecuteRandomEventSequence { mechanicPoolName = "ProteanStackPool", mechanicIndex = 0 },
					new WaitEvent { timeToWait = 12},
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new ExecuteRandomEventSequence { mechanicPoolName = "BusterPool", mechanicIndex = 0 },
					new WaitEvent { timeToWait = 12 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new ExecuteRandomEventSequence { mechanicPoolName = "ProteanStackPool", mechanicIndex = 1 },
					new WaitEvent { timeToWait = 12},
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new ExecuteRandomEventSequence { mechanicPoolName = "BusterPool", mechanicIndex = 1 },
					new WaitEvent { timeToWait = 12 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					//*/
					
					
					// Tile Phase
					//*
					new SetEnemyMovement { position = new Vector2(0, 0), movementTime = 1 },
					new SetEnemyBaseSpeed { baseMoveSpeed = 0 },
					new WaitEvent { timeToWait = 1 },
					new SetEnemyMovement { position = new Vector2(0, -1), movementTime = -3},
					new WaitEvent { timeToWait = 1 },
					
					new StartCastBar { castName = "Empty Plane", duration = 10 },
					new WaitEvent { timeToWait = 10 },
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide2" },
					new SpawnMechanicEvent { referenceMechanicName = "SpawnAllTiles" },
					new SpawnMechanicEvent { referenceMechanicName = "Tile-DeathSquare", position = new Vector2(0, -1) },
					new WaitEvent { timeToWait = 2 },
					
					new ExecuteRandomEvents { mechanicPoolName = "TurnRandomCardinal" },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "The Art of Darkness", duration = 10 },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeLR" },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeClonePool" },
					new WaitEvent { timeToWait = 12},
					
					new StartCastBar { castName = "Particle Concentration", duration = 4 },
					new WaitEvent { timeToWait = 4 },
					new ExecuteRandomEvents { mechanicPoolName = "CloseTowers", numberToSpawn = 4 },
					new ExecuteRandomEvents { mechanicPoolName = "FarTowers", numberToSpawn = 4 },
					new WaitEvent { timeToWait = 2 },
					new ExecuteRandomEventSequence { mechanicPoolName = "ProteanStackPool", mechanicIndex = 0 },
					new WaitEvent { timeToWait = 12},

					new ExecuteRandomEvents { mechanicPoolName = "TurnRandomCardinal" },
					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "ParticleBeamFormationA", isPositionRelative = true, isRotationRelative = true},
					new WaitEvent { timeToWait = 14 },

					new ExecuteRandomEvents { mechanicPoolName = "TurnRandomIntercard" },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "The Art of Darkness", duration = 10 },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeLR" },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeClonePool" },
					new WaitEvent { timeToWait = 12},

					new StartCastBar { castName = "Particle Concentration", duration = 4 },
					new WaitEvent { timeToWait = 4 },
					new ExecuteRandomEvents { mechanicPoolName = "CloseTowers", numberToSpawn = 4 },
					new ExecuteRandomEvents { mechanicPoolName = "FarTowers", numberToSpawn = 4 },
					new WaitEvent { timeToWait = 2 },
					new ExecuteRandomEventSequence { mechanicPoolName = "ProteanStackPool", mechanicIndex = 1 },
					new WaitEvent { timeToWait = 12},

					new ExecuteRandomEvents { mechanicPoolName = "TurnRandomCardinal" },
					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "ParticleBeamFormationB", isPositionRelative = true, isRotationRelative = true},
					new WaitEvent { timeToWait = 14 },

					new StartCastBar { castName = "Deluge of Darkness", duration = 10 },
					new WaitEvent { timeToWait = 10 },
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide3" },

					new ClearMechanicsWithTag { mechanicTag = "Tiles" },
					new SetEnemyBaseSpeed { baseMoveSpeed = 2 },
					//*/
					
					// Phase 3
					//*
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					
					new StartCastBar { castName = "Everlasting Brambles", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Brambles", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2, 3, 4, 5, 6, 7} } },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new ReshuffleMechanicPoolIds { mechanicPoolName = "BusterPool" },
					new ExecuteRandomEventSequence { mechanicPoolName = "BusterPool", mechanicIndex = 0 },
					new WaitEvent { timeToWait = 12 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },

					new StartCastBar { castName = "Ground-razing Particle Beam", duration = 4 },
					new WaitEvent { timeToWait = 4},
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide1" },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },

					new ExecuteRandomEvents { mechanicPoolName = "MoveRandomCardinal" },
					new WaitEvent { timeToWait = 3 },
					new SetEnemyMovement { position = new Vector2(0, 0), movementTime = -15 },
					new WaitEvent { timeToWait = 1 },
					new ExecuteRandomEventSequence { mechanicPoolName = "ParticleBeamFormationPool", mechanicIndex = 0},
					new WaitEvent { timeToWait = 14 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new StartCastBar { castName = "Everlasting Brambles", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Brambles", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2, 3, 4, 5, 6, 7} } },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					
					new ExecuteRandomEventSequence { mechanicPoolName = "BusterPool", mechanicIndex = 1 },
					new WaitEvent { timeToWait = 12 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },

					new StartCastBar { castName = "Ground-razing Particle Beam", duration = 4 },
					new WaitEvent { timeToWait = 4},
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide1" },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					
					new ExecuteRandomEvents { mechanicPoolName = "MoveRandomCardinal" },
					new WaitEvent { timeToWait = 3 },
					new SetEnemyMovement { position = new Vector2(0, 0), movementTime = -15 },
					new WaitEvent { timeToWait = 1 },
					new ExecuteRandomEventSequence { mechanicPoolName = "ParticleBeamFormationPool", mechanicIndex = 1},
					new WaitEvent { timeToWait = 14 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new SpawnMechanicEvent { referenceMechanicName = "DualBuster", isPositionRelative = true },
					new WaitEvent { timeToWait = 12 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					//*/
					
					// Tile Phase 2
					//*
					new SetEnemyMovement { position = new Vector2(0, 0), movementTime = 1 },
					new SetEnemyBaseSpeed { baseMoveSpeed = 0 },
					new WaitEvent { timeToWait = 1 },
					new SetEnemyMovement { position = new Vector2(0, -1), movementTime = -3},
					new WaitEvent { timeToWait = 1 },

					new StartCastBar { castName = "Empty Plane", duration = 10 },
					new WaitEvent { timeToWait = 10 },
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide2" },
					new SpawnMechanicEvent { referenceMechanicName = "SpawnAllTiles" },
					new SpawnMechanicEvent { referenceMechanicName = "Tile-DeathSquare", position = new Vector2(0, -1) },
					new WaitEvent { timeToWait = 2 },

					new ExecuteRandomEvents { mechanicPoolName = "TurnRandomCardinal" },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "The Art of Darkness", duration = 10 },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeLR" },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeClonePool" },
					new WaitEvent { timeToWait = 12},

					new SpawnMechanicEvent { referenceMechanicName = "DualBuster", isPositionRelative = true },
					new WaitEvent { timeToWait = 12 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },

					new StartCastBar { castName = "Everlasting Brambles", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Brambles", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2, 3, 4, 5, 6, 7} } },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new ExecuteRandomEvents { mechanicPoolName = "TurnRandomIntercard" },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "The Art of Darkness", duration = 10 },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeLR" },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeClonePool" },
					new WaitEvent { timeToWait = 12},

					new StartCastBar { castName = "Everlasting Brambles", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Brambles", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2, 3, 4, 5, 6, 7} } },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new ExecuteRandomEvents { mechanicPoolName = "TurnRandomCardinal" },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "The Art of Darkness", duration = 10 },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeLR" },
					new WaitEvent { timeToWait = 12},
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new ExecuteRandomEvents { mechanicPoolName = "TurnRandomIntercard" },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "The Art of Darkness", duration = 10 },
					new ExecuteRandomEvents { mechanicPoolName = "SwipeLR" },
					new WaitEvent { timeToWait = 12},
					
					new StartCastBar { castName = "Everlasting Brambles", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Brambles", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2, 3, 4, 5, 6, 7} } },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					//*/

					new StartCastBar { castName = "Flood of Darkness", duration = 30 },
					new WaitEvent { timeToWait = 30 },
					new SpawnMechanicEvent { referenceMechanicName = "Enrage" },

					new WaitEvent { timeToWait = 1000 },
				}
			}
		}
	},
	{
		"DualBuster",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new StartCastBar { castName = "Dual Force Particle Beam", duration = 10 },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "LongRangeBuster-1",
						isPositionRelative = true,
						targetingScheme = new TargetSpecificProximityPlayers
						{
							targetNthFarthest = true,
							targetIds = new List<int> {0}
						}
					},
					new SpawnTargetedEvents
					{
						referenceMechanicName = "AntiTankBuster-1",
						isPositionRelative = true,
						targetingScheme = new TargetNthHighestAggro()
					},
					new WaitEvent { timeToWait = 11 },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "LongRangeBusterLaser",
						isPositionRelative = true,
						targetingScheme = new TargetSpecificProximityPlayers
						{
							targetNthFarthest = true,
							targetIds = new List<int> {0}
						}
					},
					new SpawnTargetedEvents
					{
						referenceMechanicName = "AntiTankBusterLaser",
						isPositionRelative = true,
						targetingScheme = new TargetNthHighestAggro()
					}
				}
			}
		}
	},
	{
		"LongRangeBuster",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new StartCastBar { castName = "Long Range Particle Beam", duration = 10 },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "LongRangeBuster-1",
						isPositionRelative = true,
						targetingScheme = new TargetSpecificProximityPlayers
						{
							targetNthFarthest = true,
							targetIds = new List<int> {0}
						}
					},
					new WaitEvent { timeToWait = 10 },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "LongRangeBusterLaser",
						isPositionRelative = true,
						targetingScheme = new TargetSpecificProximityPlayers
						{
							targetNthFarthest = true,
							targetIds = new List<int> {0}
						}
					}
				}
			}
		}
	},
	{
		"LongRangeBuster-1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#dc70ff", visualDuration = 3, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), isBillboard = true },
					new WaitEvent { timeToWait = 9.5f },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "LongRangeBusterLaser",
						isPositionRelative = true,
						targetingScheme = new TargetExistingTarget()
					}
				}
			}
		}
	},
	{
		"LongRangeBusterLaser",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(20, 2),
			colorHtml = "#5e0066",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new WildChargeDamageEffect { damageAmountFront = 400000, damageAmountBack = 160000, maxStackAmount = 2, damageType = "Magic", name = "Long-range Particle Beam" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						}
					}
				}
			}
		}
	},
	{
		"AntiTankBuster",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new StartCastBar { castName = "Anti Tank Particle Beam", duration = 10 },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "AntiTankBuster-1",
						isPositionRelative = true,
						targetingScheme = new TargetNthHighestAggro()
					},
					new WaitEvent { timeToWait = 10 },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "AntiTankBusterLaser",
						isPositionRelative = true,
						targetingScheme = new TargetNthHighestAggro()
					}
				}
			}
		}
	},
	{
		"AntiTankBuster-1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new WaitEvent { timeToWait = 9.5f },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "AntiTankBusterLaser",
						isPositionRelative = true,
						targetingScheme = new TargetExistingTarget()
					}
				}
			}
		}
	},
	{
		"AntiTankBusterLaser",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(20, 2),
			colorHtml = "#5e0066",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 200000, damageType = "Physical", name = "Anti-tank Particle Beam" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" },
						}
					}
				}
			}
		}
	},
	{
		"ParticleBeamFormationA",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new StartCastBar { castName = "Particle Beam Formation A", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true },
					new WaitEvent { timeToWait = 2 },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true },
					new SpawnTargetedEvents {
						referenceMechanicName = "WideCone-T",
						spawnOnTarget = false,
						targetingScheme = new TargetSpecificPlayerIdsByClass
						{
							classType = PlayerClassType.Tank,
							targetIds = new List<int> {0, 1}
						},
						isPositionRelative = true,
					},
					new SpawnTargetedEvents {
						referenceMechanicName = "Chariot-H",
						spawnOnTarget = false,
						targetingScheme = new TargetSpecificPlayerIdsByClass
						{
							classType = PlayerClassType.Healer,
							targetIds = new List<int> {0, 1}
						}
					},
					new WaitEvent { timeToWait = 3 },
					new SpawnMechanicEvent { referenceMechanicName = "WideCone", isPositionRelative = true, isRotationRelative = true, rotation = 90},
					new SpawnMechanicEvent { referenceMechanicName = "WideCone", isPositionRelative = true, isRotationRelative = true, rotation = -90},
				}
			}
		}
	},
	{
		"ParticleBeamFormationB",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new StartCastBar { castName = "Particle Beam Formation B", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SpawnMechanicEvent { referenceMechanicName = "WideCone", isPositionRelative = true, isRotationRelative = true, rotation = 90},
					new SpawnMechanicEvent { referenceMechanicName = "WideCone", isPositionRelative = true, isRotationRelative = true, rotation = -90},
					new WaitEvent { timeToWait = 2 },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true },
					new SpawnTargetedEvents {
						referenceMechanicName = "Chariot-T",
						spawnOnTarget = false,
						targetingScheme = new TargetSpecificPlayerIdsByClass
						{
							classType = PlayerClassType.Tank,
							targetIds = new List<int> {0, 1}
						},
					},
					new SpawnTargetedEvents {
						referenceMechanicName = "WideCone-H",
						spawnOnTarget = false,
						targetingScheme = new TargetSpecificPlayerIdsByClass
						{
							classType = PlayerClassType.Healer,
							targetIds = new List<int> {0, 1}
						},
						isPositionRelative = true,
					},
					new WaitEvent { timeToWait = 3 },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true },
				}
			}
		}
	},
	{
		"Chariot",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(3, 360),
			colorHtml = "#5e0066",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 200000, damageType = "Magic", name = "Anti-air Particle Beam" },
							new ApplyStatusEffect { referenceStatusName = "DamageDown" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" }
						}
					}
				}
			}
		}
	},
	{
		"Chariot-T",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(3, 360),
			colorHtml = "#5e0066",
			visible = true,
			isTargeted = true,
			followSpeed = 100,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 120000, damageType = "Magic", name = "Condensed Anti-air Particle Beam" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" }
						}
					}
				}
			}
		}
	},
	{
		"Chariot-H",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#5e0066",
			visible = true,
			isTargeted = true,
			followSpeed = 100,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 300000, damageType = "Magic", name = "Heavy Anti-air Particle Beam", maxStackAmount = 3 },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" }
						}
					}
				}
			}
		}
	},
	{
		"Dynamo",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(20, 360, 3),
			colorHtml = "#5e0066",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 200000, damageType = "Magic", name = "Full-perimeter Particle Beam" },
							new ApplyStatusEffect { referenceStatusName = "DamageDown" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" }
						}
					}
				}
			}
		}
	},
	{
		"WideCone",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(20, 120),
			colorHtml = "#5e0066",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 200000, damageType = "Magic", name = "Wide-angle Particle Beam" },
							new ApplyStatusEffect { referenceStatusName = "DamageDown" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" }
						}
					}
				}
			}
		}
	},
	{
		"WideCone-T",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(20, 30),
			colorHtml = "#5e0066",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 120000, damageType = "Magic", name = "Condensed Wide-angle Particle Beam" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						}
					}
				}
			}
		}
	},
	{
		"WideCone-H",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(20, 30),
			colorHtml = "#5e0066",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 300000, damageType = "Magic", name = "Heavy Wide-angle Particle Beam", maxStackAmount = 3 },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						}
					}
				}
			}
		}
	},
	{
		"Tile-Mechanic",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents 
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "Tile-Base", isPositionRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "Tile-Warning", isPositionRelative = true },
				}
			}
		}
	},
	{
		"Tile-Base",
		new MechanicProperties {
			mechanicTag = "Tiles",
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(2, 2),
			visible = false,
			colorHtml = "#bc74de",
			
			persistentTickInterval = 0.1f,
			persistentMechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new CheckNumberOfPlayers
					{
						ignoreInvincible = true,
						expressionFormat = "{0} > 1",
						successEvent = new ExecuteMultipleEvents {
							events = new List<MechanicEvent>
							{
								new SpawnMechanicEvent { referenceMechanicName = "Tile-Fail", isPositionRelative = true },
								new PausePersistentEvent { duration =  5 },
							}
						}
					},
					new CheckNumberOfPlayers
					{
						ignoreInvincible = true,
						expressionFormat = "{0} < 1",
						successEvent = new ExecuteMultipleEvents {
							events = new List<MechanicEvent>
							{
								new ModifyMechanicEvent { referenceMechanicName = "Tile-Base" },
								new ResetMechanicTimer(),
							}
						},
						failEvent = new ModifyMechanicEvent { referenceMechanicName = "Tile-Active" }
					}
				}
			}
		}
	},
	{
		"Tile-Active",
		new MechanicProperties {
			visible = true,
		}
	},
	{
		"Tile-Warning",
		new MechanicProperties {
			mechanicTag = "Tiles",
			visible = false,
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(2, 2),
			colorHtml = "#fff600",
			
			persistentTickInterval = 0.1f,
			persistentMechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>() {
					new CheckNumberOfPlayers
					{
						ignoreInvincible = true,
						expressionFormat = "{0} < 1",
						successEvent = new ExecuteMultipleEvents {
							events = new List<MechanicEvent>
							{
								new ModifyMechanicEvent { referenceMechanicName = "Tile-Warning" },
								new ResetMechanicTimer(),
							}
						}
					},
					new CheckMechanicTimer {
						expressionFormat = "{0} > 10",
						successEvent = new ModifyMechanicEvent { referenceMechanicName = "Tile-Warning-Visible" },
					},
					new CheckMechanicTimer {
						expressionFormat = "{0} > 15",
						successEvent = new ExecuteMultipleEvents {
							events = new List<MechanicEvent>
							{
								new SpawnMechanicEvent { referenceMechanicName = "Tile-Fail", isPositionRelative = true },
								new ModifyMechanicEvent { referenceMechanicName = "Tile-Warning" },
								new PausePersistentEvent { duration =  5 },
							}
						}
					},
				}
			}
		}
	},
	{
		"Tile-Warning-Visible",
		new MechanicProperties {
			visible = true,
		}
	},
	{
		"Tile-Fail",
		new MechanicProperties {
			mechanicTag = "Tiles",
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(2, 2),
			colorHtml = "#FF0000",
			mechanic = new WaitEvent { timeToWait = 5 },
			
			persistentActivationDelay = 0.5f,
			persistentTickInterval = 0.1f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage" } },
		}
	},
	{
		"Tile-DeathSquare",
		new MechanicProperties {
			mechanicTag = "Tiles",
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(2, 2),
			colorHtml = "#FF0000",
			
			persistentActivationDelay = 0.5f,
			persistentTickInterval = 0.1f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage" } },
		}
	},
	{
		"Swipe-Clone",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/CloudOfDarkness.png",
						visualDuration = 10,
						colorHtml = "#b429bd",
						relativePosition = new Vector3(0, 1, 0),
						scale = new Vector3(1, 1.2367f, 1) * 3,
						isRotationRelative = true,
					},
					new ExecuteRandomEvents { mechanicPoolName = "SwipeLR" }
				}
			}
		}
	},
	{
		"SwipeR-Cast",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/CloudOfDarknessAdd.png",
						visualDuration = 10,
						colorHtml = "#b429bd",
						isBillboard = true,
						relativePosition = new Vector3(1.5f, 1.5f, 0),
						scale = new Vector3(1, 1, 1),
					},
					new WaitEvent { timeToWait = 9.5f },
					new SpawnMechanicEvent
					{
						referenceMechanicName = "Swipe",
						rotation = 90,
						isRotationRelative = true,
						isPositionRelative = true,
					}
				}
			}
		}
	},
	{
		"SwipeL-Cast",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/CloudOfDarknessAdd.png",
						visualDuration = 10,
						colorHtml = "#b429bd",
						isBillboard = true,
						relativePosition = new Vector3(-1.5f, 1.5f, 0),
						scale = new Vector3(1, 1, 1),
					},
					new WaitEvent { timeToWait = 9.5f },
					new SpawnMechanicEvent
					{
						referenceMechanicName = "Swipe",
						rotation = -90,
						isRotationRelative = true,
						isPositionRelative = true,
					}
				}
			}
		}
	},
	{
		"Swipe",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(20, 180),
			colorHtml = "#5e0066",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 90000, damageType = "Magic", name = "The Art of Darkness" },
							new KnockbackEffect { knockbackDistance = 20 },
							new ApplyStatusEffect { referenceStatusName = "DamageDown" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" }
						}
					}
				}
			}
		}
	},
	{
		"ProteanCast",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new StartCastBar { castName = "The Art of Darkness", duration = 10 },
					new WaitEvent { timeToWait = 9.5f },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "ProteanLaser",
						isPositionRelative = true,
						targetingScheme = new TargetSpecificPlayerIds
						{
							targetIds = new List<int> {0, 1, 2, 3, 4, 5, 6, 7}
						}
					}
				}
			}
		}
	},
	{
		"ProteanLaser",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(20, 2),
			colorHtml = "#5e0066",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 90000, damageType = "Magic", name = "Multi-pronged Particle Beam" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						}
					}
				}
			}
		}
	},
	{
		"PartnerStackCast",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new StartCastBar { castName = "The Art of Darkness", duration = 10 },
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/CloudOfDarknessAdd.png",
						visualDuration = 10,
						colorHtml = "#b429bd",
						isBillboard = true,
						relativePosition = new Vector3(1.5f, 1.5f, 0),
						scale = new Vector3(1, 1, 1),
					},
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/CloudOfDarknessAdd.png",
						visualDuration = 10,
						colorHtml = "#b429bd",
						isBillboard = true,
						relativePosition = new Vector3(-1.5f, 1.5f, 0),
						scale = new Vector3(1, 1, 1),
					},
					new WaitEvent { timeToWait = 9.5f },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "PartnerStack",
						isPositionRelative = true,
						spawnOnTarget = true,
						targetingScheme = new TargetSpecificPlayerIdsByClass
						{
							classType = PlayerClassType.Dps,
							targetIds = new List<int> {0, 1, 2, 3}
						}
					}
				}
			}
		}
	},
	{
		"PartnerStack",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#5e0066",
			isTargeted = true,
			followSpeed = 100,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 180000, damageType = "Magic", name = "Hyper-focused Particle Beam", maxStackAmount = 2 },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						}
					}
				}
			}
		}
	},
	{
		"Tower Fail",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(50, 360),
			colorHtml = "#FF0000",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Particle Blast" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" }
						}
					}
				}
			}
		}
	},
	{
		"Tower",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.75f, 360),
			colorHtml = "#FFFF00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Tower.png", colorHtml = "#FFFF00", visualDuration = 8, relativePosition = Vector3.up, scale = new Vector3(1, 1.8876f, 1) * 0.6f, eulerAngles = new Vector3(0, 0, 0), isBillboard = true },
					new WaitEvent { timeToWait = 8 },
					new CheckNumberOfPlayers
					{
						expressionFormat = "{0} = 1",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "Tower Fail", isPositionRelative = true }
					},
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 5000, damageType = "Damage", name = "Particle Beam" }
					}
				}
			}
		}
	},
	{
		"Brambles",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#5e0066",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers
					{ 
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 50000, damageType = "Magic", name = "Everlasting Brambles" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						}
					},
					new WaitEvent { timeToWait = 10000 },
				}
			},
			
			persistentTickInterval = 0.3f,
			persistentActivationDelay = 2,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 999999, damageType = "TrueDamage", name = "Bleeding" } },
		}
	},
	{
		"AutoAttack",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new DamageEffect { damageAmount = 40000, damageType = "Damage" }
			}
		}
	},
	{
		"Raidwide1",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 70000, damageType = "Damage", name = "Ground-razing Particle Beam" }
			}
		}
	},
	{
		"Raidwide2",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 100000, damageType = "Damage", name = "Empty Plane" }
			}
		}
	},
	{
		"Raidwide3",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 100000, damageType = "Damage", name = "Deluge of Darkness" }
			}
		}
	},
	{
		"Enrage",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage", name = "Flood of Darkness" }
			}
		}
	},
	{
		"ArenaBoundary",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(30, 270),
			colorHtml = "#8800FF",
			
			persistentTickInterval = 0.1f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage" } },
		}
	}
};

List<MechanicEvent> allTiles = new List<MechanicEvent>();
List<MechanicEvent> closeTowers = new List<MechanicEvent>();
List<MechanicEvent> farTowers = new List<MechanicEvent>();

for (int i = -2; i <= 2; i++) {
	for (int j = -2; j <= 2; j++)
	{
		if (i == 0 && j == 0)
		{
			continue;
		}
		
		allTiles.Add(new SpawnMechanicEvent
		{
			referenceMechanicName = "Tile-Mechanic",
			position = new Vector2(i * 2, j * 2 - 1)
		});
		
		if (i == 2 || i == -2 || j == 2 || j == -2) {
			farTowers.Add(new SpawnMechanicEvent
			{
				referenceMechanicName = "Tower",
				position =  new Vector2(i * 2, j * 2)
			});
		}
		else
		{
			closeTowers.Add(new SpawnMechanicEvent
			{
				referenceMechanicName = "Tower",
				position = new Vector2(i * 2, j * 2)
			});
		}
	}
}

mechanicData.referenceMechanicProperties["SpawnAllTiles"] = new MechanicProperties
{
	visible = false,
	mechanic = new ExecuteMultipleEventsParallel { events = allTiles }
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"Vuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/VulnStack.png",
			statusName = "Vulnerability Up",
			statusDescription = "Damage taken is increased.",
			damageMultiplier = 1.1f,
			maxStacks = 16,
			duration = 45,
		}
	},
	{
		"DamageDown",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/DamageDown.png",
			statusName = "Damage Down",
			statusDescription = "Damage dealt is reduced.",
			duration = 60,
		}
	},
	{
		"MagicVuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/MagicVuln.png",
			statusName = "Magic Vulnerability Up",
			statusDescription = "Magic damage taken is increased.",
			damageType = "Magic",
			damageMultiplier = 8,
			duration = 3,
		}
	},
	{
		"PhysVuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/PhysVuln.png",
			statusName = "Physical Vulnerability Up",
			statusDescription = "Physical damage taken is increased.",
			damageType = "Physical",
			damageMultiplier = 8,
			duration = 3,
		}
	}
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" , position = new Vector2(-5, 5), rotation = -45 },
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" , position = new Vector2(5, -5), rotation = 135 },
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaSquare5x5.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(12.9722f, 12.9722f, 1),
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>
		{
			new WaitEvent { timeToWait = 1 },
			new SpawnEnemy {
				enemyName = "Cloud of Darkness",
				textureFilePath = "Mechanics/Resources/CloudOfDarkness.png",
				colorHtml = "#b429bd",
				maxHp = 35000000,
				baseMoveSpeed = 2,
				hitboxSize = 4,
				visualPosition = new Vector3(0, 1, 0),
				visualScale = new Vector3(1, 1.2367f, 1) * 3,
				referenceMechanicName = "CloudOfDarknessMechanics",
				rotation = 180,

				//textureFilePath = "Mechanics/Resources/NidhoggThordan.png",
				//colorHtml = "#1b043c",
				//visualPosition = new Vector3(0, 1.46f, 0),
				//visualScale = new Vector3(1.66f, 1, 1) * 3,
			}
		}
	}
};

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"SwipeLR",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "SwipeL-Cast", isPositionRelative = true, isRotationRelative = true},
			new SpawnMechanicEvent {referenceMechanicName = "SwipeR-Cast", isPositionRelative = true, isRotationRelative = true}
		}
	},
	{
		"SwipeClonePool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "Swipe-Clone", isPositionRelative = true, isRotationRelative = true, position = new Vector2(5, 0), rotation = 90},
			new SpawnMechanicEvent {referenceMechanicName = "Swipe-Clone", isPositionRelative = true, isRotationRelative = true, position = new Vector2(-5, 0), rotation = -90}
		}
	},
	{
		"ProteanStackPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "ProteanCast", isPositionRelative = true, isRotationRelative = true},
			new SpawnMechanicEvent {referenceMechanicName = "PartnerStackCast", isPositionRelative = true, isRotationRelative = true}
		}
	},
	{
		"BusterPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "LongRangeBuster", isPositionRelative = true},
			new SpawnMechanicEvent {referenceMechanicName = "AntiTankBuster", isPositionRelative = true}
		}
	},
	{
		"ParticleBeamFormationPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent { referenceMechanicName = "ParticleBeamFormationA", isPositionRelative = true, isRotationRelative = true},
			new SpawnMechanicEvent { referenceMechanicName = "ParticleBeamFormationB", isPositionRelative = true, isRotationRelative = true},
		}
	},
	{
		"TurnRandomCardinal",
		new List<MechanicEvent> {
			new SetEnemyMovement { position = new Vector2(1, 0), movementTime = -15},
			new SetEnemyMovement { position = new Vector2(0, 1), movementTime = -15},
			new SetEnemyMovement { position = new Vector2(-1, 0), movementTime = -15},
			new SetEnemyMovement { position = new Vector2(0, -1), movementTime = -15},
		}
	},
	{
		"TurnRandomIntercard",
		new List<MechanicEvent> {
			new SetEnemyMovement { position = new Vector2(1, 1), movementTime = -15},
			new SetEnemyMovement { position = new Vector2(-1, -1), movementTime = -15},
			new SetEnemyMovement { position = new Vector2(-1, 1), movementTime = -15},
			new SetEnemyMovement { position = new Vector2(1, -1), movementTime = -15},
		}
	},
	{
		"MoveRandomCardinal",
		new List<MechanicEvent> {
			new SetEnemyMovement { position = new Vector2(5, 0), movementTime = 3},
			new SetEnemyMovement { position = new Vector2(0, 5), movementTime = 3},
			new SetEnemyMovement { position = new Vector2(-5, 0), movementTime = 3},
			new SetEnemyMovement { position = new Vector2(0, -5), movementTime = 3},
		}
	},
	{
		"CloseTowers", closeTowers
	},
	{
		"FarTowers", farTowers
	}
};


((ExecuteMultipleEvents)mechanicData.referenceMechanicProperties["CloudOfDarknessMechanics"].mechanic).events.Where(x => x is WaitEvent).Sum(x => ((WaitEvent)x).timeToWait).Dump();

var resultText = JsonConvert.SerializeObject(mechanicData, Newtonsoft.Json.Formatting.Indented).Replace(", Assembly-CSharp", "");

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

if (Directory.Exists(@"D:\src\Builds\XivMechanicSimNetworked - Short E9S Tile Demo\Mechanics"))
{
	File.WriteAllText($@"D:\src\Builds\XivMechanicSimNetworked - Short E9S Tile Demo\Mechanics\{mechanicName}.json", resultText);
}

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "UcobAddsDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"TwintaniaMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new SetEnemyAggro { targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Tank, targetIds = new List<int> {0} } },

					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },

					new SpawnTargetedEvents { referenceMechanicName = "Plummet", targetingScheme = new TargetNthHighestAggro(), isPositionRelative = true }, // t = 0
					
					new WaitEvent { timeToWait = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					
					new SetEnemyBaseSpeed { baseMoveSpeed = 0 },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "Generate", duration = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "Hatch", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {0, 1, 2} } },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },

					new SetEnemyBaseSpeed { baseMoveSpeed = 2 },

					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					
					new ReshufflePlayerIds(),
					new StartCastBar { castName = "Twister", duration = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "Twister", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 }, dropExtraEvents = true } },

					new WaitEvent { timeToWait = 3 }, // t = 16
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2 }, // t = 30

					new ReshufflePlayerIds(),
					new StartCastBar { castName = "Twister", duration = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "Twister", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 }, dropExtraEvents = true } },
					
					new WaitEvent { timeToWait = 3 }, // t = 33
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2 }, // t = 47
					
					new StartCastBar { castName = "Death Sentence", duration = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "TankBuster-T", targetingScheme = new TargetNthHighestAggro() }, // t = 52
					new WaitEvent { timeToWait = 5 },
					
					// Part 2
					
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new SpawnTargetedEvents { referenceMechanicName = "Plummet", targetingScheme = new TargetNthHighestAggro(), isPositionRelative = true }, // t = 56

					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() }, 
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2 }, // t = 1:10


					new SetEnemyBaseSpeed { baseMoveSpeed = 0 },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "Generate", duration = 3 },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "Hatch", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {0, 1, 2} } },
					
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificProximityPlayers { targetNthFarthest = true, targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1 },
					
					new SetEnemyBaseSpeed { baseMoveSpeed = 2 },

					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },

					new ReshufflePlayerIds(),
					new StartCastBar { castName = "Twister", duration = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "Twister", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 }, dropExtraEvents = true } },

					new WaitEvent { timeToWait = 3 }, // t = 1:19
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2 }, // t = 1:33
					
					new ReshufflePlayerIds(),
					new StartCastBar { castName = "Twister", duration = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "Twister", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 }, dropExtraEvents = true } },

					new WaitEvent { timeToWait = 3 }, // t = 1:36
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2 }, // t = 1:43
					
					new StartCastBar { castName = "Death Sentence", duration = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "TankBuster-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 6 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-T", targetingScheme = new TargetNthHighestAggro() },


					new WaitEvent { timeToWait = float.PositiveInfinity },
				}
			}
		}
	},
	{
		"NaelMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new SetEnemyAggro { targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Tank, targetIds = new List<int> {0} } },

					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },

					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() }, // t=0
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() },

					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 }, // t = 19
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },

					new ReshufflePlayerIds(),
					new SetEnemyBaseSpeed { baseMoveSpeed = 0 },
					new ExecuteRandomEventSequence { mechanicPoolName = "Quote-Pool", mechanicIndex = 0 },
					
					new SetEnemyBaseSpeed { baseMoveSpeed = 2 },
					new WaitEvent { timeToWait = 1 }, // t = 31
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2 }, // t = 39
					
					new StartCastBar { castName = "Megaflare", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide1" }, // t = 44

					new WaitEvent { timeToWait = 3 }, // t = 47
					new StartCastBar { castName = "Ravensbeak", duration = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "TankBuster-N", targetingScheme = new TargetNthHighestAggro() }, // t = 52
					new WaitEvent { timeToWait = 6 },
					
					// Part 2
					
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() }, 
					new WaitEvent { timeToWait = 1 }, // t = 1:00
					
					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SmallBuster-N", targetingScheme = new TargetNthHighestAggro() },

					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() }, 
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() }, // t = 1:10
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2 }, // t = 1:21
					
					new ReshufflePlayerIds(),
					new SetEnemyBaseSpeed { baseMoveSpeed = 0 },
					new ExecuteRandomEventSequence { mechanicPoolName = "Quote-Pool", mechanicIndex = 1 },

					new SetEnemyBaseSpeed { baseMoveSpeed = 2 },
					new WaitEvent { timeToWait = 1 }, // t = 1:33
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2 },

					new StartCastBar { castName = "Ravensbeak", duration = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "TankBuster-N", targetingScheme = new TargetNthHighestAggro() }, // t = 1:49
					new WaitEvent { timeToWait = 6 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new StartCastBar { castName = "Megaflare", duration = 5 },
					new WaitEvent { timeToWait = 5},
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide1" }, // t = 2:01

					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack-N", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },

					new WaitEvent { timeToWait = float.PositiveInfinity },
				}
			}
		}
	},
	{
		"Twister Explode",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(3, 360),
			colorHtml = "#008542",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Twister" },
							new KnockbackEffect { knockbackDistance = 10 },
						}
					}
				}
			}
		}
	},
	{
		"TwisterSnapshot",
		new MechanicProperties
		{
			isTargeted = false,
			followSpeed = 0,
		}
	},
	{
		"TwisterVisible",
		new MechanicProperties
		{
			visible = true,
		}
	},
	{
		"Twister",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.25f, 360),
			colorHtml = "#008542",
			visible = false,
			isTargeted = true,
			followSpeed = 100,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1.5f },
					new ModifyMechanicEvent { referenceMechanicName = "TwisterSnapshot" },
					new WaitEvent { timeToWait = 0.5f },
					new ModifyMechanicEvent { referenceMechanicName = "TwisterVisible" },
					new WaitEvent { timeToWait = 5 },
				}
			},
			persistentTickInterval = 0.1f,
			persistentActivationDelay = 2.5f,
			persistentMechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new CheckNumberOfPlayers
					{
						expressionFormat = "{0} = 0",
						failEvent = new ExecuteMultipleEvents{
							events = new List<MechanicEvent> {
								new SpawnMechanicEvent { referenceMechanicName = "Twister Explode", isPositionRelative = true },
								new EndMechanic()
							}
						}
					},
				}
			},
		}
	},
	{
		"Plummet",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(5, 90),
			colorHtml = "#7c7c7c",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 100000, damageType = "Damage", name = "Plummet" },
					}
				}
			}
		}
	},
	{
		"Liquid Hell",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 360),
			colorHtml = "#ff7200",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Liquid Hell" } },
					new WaitEvent { timeToWait = 10 },
				}
			},

			persistentTickInterval = 0.3f,
			persistentActivationDelay = 2,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Burns" } },
		}
	},
	{
		"Neurolink",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.4f, 360),
			colorHtml = "#9cff00",

			persistentTickInterval = 0.2f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new ApplyStatusEffect { referenceStatusName = "Neurolink" } },
		}
	},
	{
		"HatchMove",
		new MechanicProperties {
			followSpeed = 1.2f,
		}
	},
	{
		"Hatch",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.4f, 360),
			colorHtml = "#a800ff",
			isTargeted = true,
			followSpeed = 0,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/LimitCut-3.png", colorHtml = "#a800ff", spawnOnPlayer = true, visualDuration = 5, isBillboard = true, relativePosition = Vector3.up * 0.8f, scale = Vector3.one * 0.5f},
					new WaitEvent { timeToWait = 3 },
					new ModifyMechanicEvent { referenceMechanicName = "HatchMove" },
					new WaitEvent { timeToWait = 20 },
					new SpawnMechanicEvent { referenceMechanicName = "HatchExplode", isPositionRelative = true },
				}
			},
			persistentTickInterval = 0.1f,
			persistentActivationDelay = 1,
			persistentMechanic = new CheckNumberOfPlayers
			{
				expressionFormat = "{0} = 0",
				failEvent = new CheckNumberOfPlayers {
					expressionFormat = "{0} = 1",
					condition = new CheckPlayerStatus { statusName = "Neurolink" },
					successEvent = new ExecuteMultipleEvents{
						events = new List<MechanicEvent> {
							new SpawnMechanicEvent { referenceMechanicName = "HatchPopped", isPositionRelative = true },
							new EndMechanic()
						}
					},
					failEvent = new ExecuteMultipleEvents{
						events = new List<MechanicEvent> {
							new SpawnMechanicEvent { referenceMechanicName = "HatchExplode", isPositionRelative = true },
							new EndMechanic()
						}
					}
				}
			},
		}
	},
	{
		"HatchPopped",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 360),
			colorHtml = "#a800ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							statusName = "Neurolink",
						},
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 30000, damageType = "Magic", name = "Hatch" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" } 
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 300000, damageType = "Magic", name = "Hatch" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" }
						}
					}
				}
			}
		}
	},
	{
		"HatchExplode",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(50, 360),
			colorHtml = "#a800ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage", name = "Deep Hatch" },
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
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(8, 360, 2f),
			colorHtml = "#910044",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 300000, damageType = "Damage", name = "Lunar Dynamo" }
					}
				}
			}
		}
	},
	{
		"Chariot",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(4, 360),
			colorHtml = "#dcdcdc",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 180000, damageType = "Damage", name = "Iron Chariot" },
							new KnockbackEffect { knockbackDistance = 10 },
						}
					}
				}
			}
		}
	},
	{
		"Stack",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#ff60ab",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 700000, damageType = "Damage", name = "Thermionic Beam", maxStackAmount = 8 }
					}
				}
			}
		}
	},
	{
		"Dive",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#370091",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerIsMechanicTarget(),
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 40000, damageType = "Damage", name = "Raven's Dive" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 40000, damageType = "Damage", name = "Raven's Dive" },
							new KnockbackEffect { knockbackDistance = 10},
						}
					}
				}
			}
		}
	},
	{
		"TankBuster-T",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new WaitEvent {timeToWait = 5},
					new ApplyEffectToTargetOnly
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Slashing", name = "Death Sentence" },
							new ApplyStatusEffect { referenceStatusName = "SlashingVuln" }
						}
					}
				}
			}
		}
	},
	{
		"TankBuster-N",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new WaitEvent {timeToWait = 5},
					new ApplyEffectToTargetOnly
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Piercing", name = "Ravensbeak" },
							new ApplyStatusEffect { referenceStatusName = "PiercingVuln" }
						}
					}
				}
			}
		}
	},
	{
		"AutoAttack-T",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new DamageEffect { damageAmount = 40000, damageType = "Slashing" }
			}
		}
	},
	{
		"AutoAttack-N",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new DamageEffect { damageAmount = 40000, damageType = "Piercing" }
			}
		}
	},
	{
		"SmallBuster-N",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new DamageEffect { damageAmount = 20000, damageType = "Piercing" , name = "Bahamut's Claw" }
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
				effect = new DamageEffect { damageAmount = 100000, damageType = "Damage", name = "Megaflare" }
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
				effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage", name = "Teraflare" }
			}
		}
	},
	{
		"ArenaBoundary",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(25, 360, 7),
			colorHtml = "#8800FF",
			persistentTickInterval = 0.2f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage" } },
		}
	},
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"SlashingVuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/SlashingVuln.png",
			statusName = "Slashing Vulnerability Up",
			statusDescription = "Slashing damage taken is increased.",
			damageType = "Slashing",
			damageMultiplier = 4,
			duration = 45,
		}
	},
	{
		"PiercingVuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/PiercingVuln.png",
			statusName = "Piercing Vulnerability Up",
			statusDescription = "Piercing damage taken is increased.",
			damageType = "Piercing",
			damageMultiplier = 4,
			duration = 45,
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
			damageMultiplier = 4,
			duration = 10,
		}
	},
	{
		"Neurolink",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/Neurolink.png",
			statusName = "Neurolink",
			statusDescription = "Neurolink",
			duration = 0.3f,
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" },
	new SpawnMechanicEvent { referenceMechanicName = "Neurolink", position = new Vector2(0, 3.7f) },
	new SpawnMechanicEvent { referenceMechanicName = "Neurolink", position = new Vector2(3.7f * 0.866f, -1.85f) },
	new SpawnMechanicEvent { referenceMechanicName = "Neurolink", position = new Vector2(-3.7f * 0.866f, -1.85f) },
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaCircle.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(15.8637f, 15.8637f, 1),
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>
		{
			new WaitEvent { timeToWait = 2},
			//*
			new SpawnEnemy {
				enemyName = "Twintania",
				textureFilePath = "Mechanics/Resources/Twintania.png",
				colorHtml = "#067743",
				maxHp = 35000000,
				baseMoveSpeed = 2,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 1, 0),
				visualScale = Vector3.one,
				referenceMechanicName = "TwintaniaMechanics",
				position = new Vector2(1, 1),
				rotation = 180
			},//*/
			new SpawnEnemy {
				enemyName = "Nael Deus Darnus",
				textureFilePath = "Mechanics/Resources/Nael.png",
				colorHtml = "#a917bf",
				maxHp = 35000000,
				baseMoveSpeed = 2,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 1, 0),
				visualScale = Vector3.one,
				referenceMechanicName = "NaelMechanics",
				position = new Vector2(-1, 1),
				rotation = 180
			},
			
			new WaitEvent { timeToWait = 140 },
			new SpawnMechanicEvent { referenceMechanicName = "Raidwide2" },
		}
	}
};
mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"Quote-Pool",
		new List<MechanicEvent>
		{
			new ExecuteRandomEventSequence { mechanicPoolName = "Mechanic-Pool-In" },
			new ExecuteRandomEventSequence { mechanicPoolName = "Mechanic-Pool-Out" },
		}
	},
	{
		"Mechanic-Pool-In",
		new List<MechanicEvent>
		{
			new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/In-Out-Spread.png", visualDuration = 5, isBillboard = true, relativePosition = Vector3.up * 2, scale = new Vector3(4.17f, 1, 1) },
					new WaitEvent { timeToWait = 5 },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true },
					new WaitEvent { timeToWait = 3 },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true },
					new WaitEvent { timeToWait = 3 },
					new SetEnemyMovement {movementTime = 0.2f, moveToTarget = new TargetSpecificPlayerIds {targetIds = new List<int> {0} } },
					new SpawnTargetedEvents { referenceMechanicName = "Dive", isPositionRelative = true, spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
				}
			},
			new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/In-Spread-Stack.png", visualDuration = 5, isBillboard = true, relativePosition = Vector3.up * 2, scale = new Vector3(4.17f, 1, 1) },
					new WaitEvent { timeToWait = 5 },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true },
					new WaitEvent { timeToWait = 3 },
					new SetEnemyMovement {movementTime = 0.2f, moveToTarget = new TargetSpecificPlayerIds {targetIds = new List<int> {0} } },
					new SpawnTargetedEvents { referenceMechanicName = "Dive", isPositionRelative = true, spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
					new ReshufflePlayerIds(),
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "Stack", isPositionRelative = true, spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
				}
			},
		}
	},
	{
		"Mechanic-Pool-Out",
		new List<MechanicEvent>
		{
			new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Out-Spread-Stack.png", visualDuration = 5, isBillboard = true, relativePosition = Vector3.up * 2, scale = new Vector3(4.17f, 1, 1) },
					new WaitEvent { timeToWait = 5 },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true },
					new WaitEvent { timeToWait = 3 },
					new SetEnemyMovement {movementTime = 0.2f, moveToTarget = new TargetSpecificPlayerIds {targetIds = new List<int> {0} } },
					new SpawnTargetedEvents { referenceMechanicName = "Dive", isPositionRelative = true, spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
					new ReshufflePlayerIds(),
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "Stack", isPositionRelative = true, spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
				}
			},
			new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Out-Stack-Spread.png", visualDuration = 5, isBillboard = true, relativePosition = Vector3.up * 2, scale = new Vector3(4.17f, 1, 1) },
					new WaitEvent { timeToWait = 5 },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "Stack", isPositionRelative = true, spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
					new ReshufflePlayerIds(),
					new WaitEvent { timeToWait = 3 },
					new SetEnemyMovement {movementTime = 0.2f, moveToTarget = new TargetSpecificPlayerIds {targetIds = new List<int> {0} } },
					new SpawnTargetedEvents { referenceMechanicName = "Dive", isPositionRelative = true, spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
				}
			},
		}
	},
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
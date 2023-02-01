<Query Kind="Statements">
  <Reference>D:\src\Unity\xiv-sim\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "CircleProgramDemo";
var baseOutputPath = @"D:\src\Unity\xiv-sim";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"OmegaMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitForAggro(),
					new WaitEvent { timeToWait = 3 },
					new StartCastBar { castName = "Circle Program", duration = 5},
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new SpawnTargetedEvents {referenceMechanicName = "Looper-1", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1} } },
					new SpawnTargetedEvents {referenceMechanicName = "Looper-2", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {2, 3} } },
					new SpawnTargetedEvents {referenceMechanicName = "Looper-3", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {4, 5} } },
					new SpawnTargetedEvents {referenceMechanicName = "Looper-4", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {6, 7} } },
					new ReshufflePlayerIds(),
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },
					new ExecuteRandomEvents { mechanicPoolName = "Towers-Pool" },
					new WaitEvent { timeToWait = 1 },
					new SpawnTethersToPlayers { referenceTetherName = "Blaster", tetherOffset = new Vector3(0, 1, 0), targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1} } },
					new StartCastBar { castName = "Blaster", duration = 8},
					new WaitEvent { timeToWait = 9 },
					new StartCastBar { castName = "", duration = 100000 },
					new SpawnTargetedEvents { referenceMechanicName = "TetherAoe", targetingScheme = new TargetTetheredPlayers(), spawnOnTarget = true },
					new WaitEvent { timeToWait = 9 },
					new SpawnTargetedEvents { referenceMechanicName = "TetherAoe", targetingScheme = new TargetTetheredPlayers(), spawnOnTarget = true },
					new WaitEvent { timeToWait = 9 },
					new SpawnTargetedEvents { referenceMechanicName = "TetherAoe", targetingScheme = new TargetTetheredPlayers(), spawnOnTarget = true },
					new WaitEvent { timeToWait = 9 },
					new SpawnTargetedEvents { referenceMechanicName = "TetherAoe", targetingScheme = new TargetTetheredPlayers(), spawnOnTarget = true },
					new WaitEvent {timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"TetherAoe" ,
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(5, 360),
			colorHtml = "#614879",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerIsMechanicTarget(),
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 60000, damageType = "Damage", name = "Blaster" },
							new ApplyStatusEffect { referenceStatusName = "HpDown" },
							new ApplyStatusEffect { referenceStatusName = "DoomStack" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 999999, damageType = "TrueDamage", name = "Blaster" },
							new ApplyStatusEffect { referenceStatusName = "HpDown" },
							new ApplyStatusEffect { referenceStatusName = "DoomStack" },
						}
					}
				}
			}
		}
	},
	{
		"ArenaBoundary",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(25, 360, 6.67f),
			colorHtml = "#8800FF",
			persistentTickInterval = 0.2f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage" } },
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
						effect = new DamageEffect { damageAmount = 9999999, damageType = "Damage", name = "Tower Failed" }
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
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#FFFF00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 10 },
					new CheckNumberOfPlayers
					{
						expressionFormat = "{0} = 1",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "Tower Fail", isPositionRelative = true }
					},
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							statusName = "Circle Program",
						},
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 60000, damageType = "Damage", name = "Circle Program" },
							new RemoveStatusEffect { referenceStatusName = "Looper-1", doExpireEvent = false },
							new RemoveStatusEffect { referenceStatusName = "Looper-1", doExpireEvent = false },
							new RemoveStatusEffect { referenceStatusName = "Looper-2", doExpireEvent = false },
							new RemoveStatusEffect { referenceStatusName = "Looper-2", doExpireEvent = false },
							new RemoveStatusEffect { referenceStatusName = "Looper-3", doExpireEvent = false },
							new RemoveStatusEffect { referenceStatusName = "Looper-3", doExpireEvent = false },
							new RemoveStatusEffect { referenceStatusName = "Looper-4", doExpireEvent = false },
							new RemoveStatusEffect { referenceStatusName = "Looper-4", doExpireEvent = false },
							new RemoveStatusEffect { referenceStatusName = "Line-1" },
							new RemoveStatusEffect { referenceStatusName = "Line-1" },
							new RemoveStatusEffect { referenceStatusName = "Line-2" },
							new RemoveStatusEffect { referenceStatusName = "Line-2" },
							new RemoveStatusEffect { referenceStatusName = "Line-3" },
							new RemoveStatusEffect { referenceStatusName = "Line-3" },
							new RemoveStatusEffect { referenceStatusName = "Line-4" },
							new RemoveStatusEffect { referenceStatusName = "Line-4" },
						},
						failedConditionEffect = new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Circle Program" }
					}
				}
			}
		}
	},
	{
		"Tower-Offset",
		new MechanicProperties {
			visible = false,
			mechanic = new SpawnMechanicEvent {referenceMechanicName = "Tower", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 4.5f }
		}
	},
	{
		"TowerSet-A",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 90},
					new WaitEvent { timeToWait = 9 },
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 180},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 270},
					new WaitEvent { timeToWait = 9 },
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 90},
					new WaitEvent { timeToWait = 9 },
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 180},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 270},
				}
			}
		}
	},
	{
		"TowerSet-B",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 180},
					new WaitEvent { timeToWait = 9 },
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 90},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 270},
					new WaitEvent { timeToWait = 9 },
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 180},
					new WaitEvent { timeToWait = 9 },
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 90},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-Offset", isPositionRelative = true, isRotationRelative = true, rotation = 270},
				}
			}
		}
	},
	{
		"Looper",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new DamageEffect { damageAmount = 99999999, damageType = "TrueDamage", name = "Circle Program" }
			}
		}
	},
	{
		"ApplyDoom",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effects = new List<MechanicEffect> {
					new ApplyStatusEffect { referenceStatusName = "Doom" },
					new RemoveStatusEffect { referenceStatusName = "DoomStack" },
				}
			}
		}
	},
	{
		"Doom",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new DamageEffect { damageAmount = 99999999, damageType = "TrueDamage", name = "Doom" }
			}
		}
	},
	{
		"AutoAttack",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new DamageEffect { damageAmount = 100000, damageType = "Damage" }
			}
		}
	},
	{
		"StartButton",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.5f, 360),
			colorHtml = "#00ff00",
			persistentTickInterval = 0.1f,
			persistentActivationDelay = 1,
			mechanicTag = "StartButton",
			persistentMechanic = new CheckNumberOfPlayers
			{
				expressionFormat = "{0} = 0",
				failEvent = new ExecuteMultipleEvents{
					events = new List<MechanicEvent> {
						new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses" },
						new ClearMechanicsWithTag { mechanicTag = "StartButton" },
					}
				}
			},
		}
	},
	{
		"SpawnBosses",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnEnemy {
						enemyName = "Omega",
						textureFilePath = "Mechanics/Resources/Omega.png",
						colorHtml = "#0a4d8b",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 10,
						visualPosition = new Vector3(0, 1.5f, 0),
						visualScale = Vector3.one * 4,
						referenceMechanicName = "OmegaMechanics",
						position = new Vector2(0, 0),
						isPositionRelative = true,
						isRotationRelative = true,
					},
				}
			}
		}
	},
};

mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"Blaster",
		new TetherProperties
		{
			colorHtml = "#ff8400",
			tetherDuration = 99,
			interceptMechanic = new SwitchTetheredPlayer(),
			oneTetherPerPlayer = true,
			tetherTag = "Blaster",
			retargetRandomPlayerOnDeath = true
		}
	},
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"HpDown",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/HpDown.png",
			statusName = "HP Down",
			statusDescription = "This is actually just a vuln.",
			damageMultiplier = 100,
			duration = 10,
		}
	},
	{
		"DoomStack",
		new SpawnMechanicOnReachStacks
		{
			statusIconPath = "Mechanics/Resources/DoomStack.png",
			statusName = "Twice-come Ruin",
			statusDescription = "Too many stacks will result in Doom.",
			referenceMechanicName = "ApplyDoom",
			requiredStacks = 2,
			maxStacks = 2,
			duration = 40,
		}
	},
	{
		"Doom",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/Doom.png",
			statusName = "Doom",
			statusDescription = "Certain death when counter reaches zero.",
			referenceMechanicName = "Doom",
			duration = 3,
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" },
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaCircle.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(15.0931f, 15.0931f, 1),
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>
		{
			new SpawnMechanicEvent { referenceMechanicName = "StartButton", position = new Vector2(0, 3) },
		}
	}
};

var towerPool = new List<MechanicEvent>();
for (int i = 0; i < 12; i++)
{
	towerPool.Add(new SpawnMechanicEvent { referenceMechanicName = "TowerSet-A", rotation = 45 + 30 * i });
	towerPool.Add(new SpawnMechanicEvent { referenceMechanicName = "TowerSet-B", rotation = 45 + 30 * i });
}

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{"Towers-Pool", towerPool},
};

var lineNames = new string[] { "Zero", "First", "Second", "Third", "Fourth" };

for (int i = 1; i <= 4; i++)
{
	mechanicData.referenceStatusProperties[$"Looper-{i}"] = new SpawnMechanicOnExpire
	{
		statusIconPath = "Mechanics/Resources/Looper.png",
		statusName = "Circle Program",
		statusDescription = "Certain death if not cleansed by a tower.",
		duration = i * 10 + 7,
		referenceMechanicName = "Looper",
		shouldKeepOnDeath = false,
		allowDuplicates = true,
	};
	mechanicData.referenceStatusProperties[$"Line-{i}"] = new StatusEffectData
	{
		statusIconPath = $"Mechanics/Resources/Line{i}.png",
		statusName = $"{lineNames[i]} in Line",
		statusDescription = $"Marked as target #{i}.",
		duration = i * 10 + 7,
		shouldKeepOnDeath = false,
		allowDuplicates = true,
	};
	mechanicData.referenceMechanicProperties[$"Looper-{i}"] = new MechanicProperties
	{
		visible = false,
		mechanic = new ExecuteMultipleEvents
		{
			events = new List<MechanicEvent>
			{
				new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = $"Looper-{i}" } },
				new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = $"Line-{i}" } },
			}
		}
	};
}

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
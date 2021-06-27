<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "TenstrikeDemo";
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
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent {timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"NaelMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent {timeToWait = 1},
					new ExecuteRandomEventSequence { mechanicPoolName = "Quote-Pool" },
					new WaitEvent {timeToWait = 7},
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "SpreadAoe", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{0, 1, 2, 3} } },
					new WaitEvent {timeToWait = float.PositiveInfinity }
				}
			}
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
		"SpreadAoe" ,
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#dcdcdc",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 80000, damageType = "Damage", name = "Meteor Stream" }
					}
				}
			}
		}
	},
	{
		"SetVisible",
		new MechanicProperties
		{
			visible = true
		}
	},
	{
		"Earthshaker",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(20, 90),
			colorHtml = "#c78825",
			isTargeted = true,
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#f0ba00", visualDuration = 6, spawnOnPlayer = true, relativePosition = Vector3.up * 0.6f, scale = new Vector3(0.8f, 0.8f, 1), isBillboard = true },
					new WaitEvent { timeToWait = 5.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 80000, damageType = "Physical", name = "Earthshaker" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" },
						},
					},
					new SpawnTargetedEvents { referenceMechanicName = "EarthshakerPuddle", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() }
				}
			}
		}
	},
	{
		"EarthshakerPuddle",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#c78825",
			mechanic = new WaitEvent { timeToWait = 10 },
			persistentTickInterval = 0.3f,
			persistentActivationDelay = 2,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 300000, damageType = "Physical", name = "Sludge" } },
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
	{
		"Neurolinks-A",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent> {
					new SpawnMechanicEvent { referenceMechanicName = "Neurolink", position = new Vector2(0, 3.7f) },
					new SpawnMechanicEvent { referenceMechanicName = "Neurolink", position = new Vector2(3.7f * 0.866f, -1.85f) },
					new SpawnMechanicEvent { referenceMechanicName = "Neurolink", position = new Vector2(-3.7f * 0.866f, -1.85f) },
				}
			}
		}
	},
	{
		"Neurolinks-B",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent> {
					new SpawnMechanicEvent { referenceMechanicName = "Neurolink", position = new Vector2(0, -3.7f) },
					new SpawnMechanicEvent { referenceMechanicName = "Neurolink", position = new Vector2(3.7f * 0.866f, 1.85f) },
					new SpawnMechanicEvent { referenceMechanicName = "Neurolink", position = new Vector2(-3.7f * 0.866f, 1.85f) },
				}
			}
		}
	},
	{
		"DoubleHatch",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/LimitCut-3.png", colorHtml = "#a800ff", spawnOnPlayer = true, visualDuration = 5, isBillboard = true, relativePosition = Vector3.up * 0.8f, scale = Vector3.one * 0.5f},
					new SpawnTargetedEvents { referenceMechanicName = "Hatch", isPositionRelative = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 4.2f },
					new SpawnTargetedEvents { referenceMechanicName = "Hatch", isPositionRelative = true, targetingScheme = new TargetExistingTarget() },
				}
			}
		}
	},
	{
		"StartButton-A",
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
						new SpawnMechanicEvent { referenceMechanicName = "Neurolinks-A" },
						new SpawnMechanicEvent { referenceMechanicName = "StartMechanics" },
						new ClearMechanicsWithTag { mechanicTag = "StartButton" },
					}
				}
			},
		}
	},
	{
		"StartButton-B",
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
						new SpawnMechanicEvent { referenceMechanicName = "Neurolinks-B" },
						new SpawnMechanicEvent { referenceMechanicName = "StartMechanics" },
						new ClearMechanicsWithTag { mechanicTag = "StartButton" },
					}
				}
			},
		}
	},
	{
		"StartMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "DoubleHatch", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2} } },
					new WaitEvent { timeToWait = 4 },
					
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "SpreadAoe", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {0} } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpreadAoe", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {1} } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpreadAoe", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {2} } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpreadAoe", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {3} } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpreadAoe", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {4} } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpreadAoe", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {5} } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpreadAoe", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {6} } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpreadAoe", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {7} } },
					
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "Earthshaker", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {0, 1, 2, 3} } },
					new WaitEvent {timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Earthshaker", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int> {4, 5, 6, 7} } },
				}
			}
		}
	}
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
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
	{
		"MagicVuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/MagicVuln.png",
			statusName = "Magic Vulnerability Up",
			statusDescription = "Magic damage taken is increased.",
			damageType = "Magic",
			damageMultiplier = 10,
			duration = 16,
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
			damageMultiplier = 10,
			duration = 16,
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
		scale = new Vector3(15.8637f, 15.8637f, 1),
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>
		{
			new SpawnMechanicEvent { referenceMechanicName = "StartButton-A", position = new Vector2(0, 3) },
			new SpawnMechanicEvent { referenceMechanicName = "StartButton-B", position = new Vector2(0, -3) },
		}
	}
};
mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"Spawn-Bosses-Pool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses-A" },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses-A", rotation = 120 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses-A", rotation = 240 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses-B" },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses-B", rotation = 120 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses-B", rotation = 240 },
		}
	},
	{
		"Quote-Pool",
		new List<MechanicEvent>
		{
			new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Fellruin-In-Spread.png", visualDuration = 6, isBillboard = true, relativePosition = Vector3.up * 2, scale = new Vector3(4.17f, 1, 1) },
					new WaitEvent { timeToWait = 6 },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true },
					new WaitEvent { timeToWait = 3 },
					new ReshufflePlayerIds(),
					new SetEnemyMovement {movementTime = 0.2f, moveToTarget = new TargetSpecificPlayerIds {targetIds = new List<int> {0} } },
					new SpawnTargetedEvents { referenceMechanicName = "Dive", isPositionRelative = true, spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
				}
			},
			new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Fellruin-Spread-In.png", visualDuration = 6, isBillboard = true, relativePosition = Vector3.up * 2, scale = new Vector3(4.17f, 1, 1) },
					new WaitEvent { timeToWait = 6 },
					new ReshufflePlayerIds(),
					new SetEnemyMovement {movementTime = 0.2f, moveToTarget = new TargetSpecificPlayerIds {targetIds = new List<int> {0} } },
					new SpawnTargetedEvents { referenceMechanicName = "Dive", isPositionRelative = true, spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
					new WaitEvent { timeToWait = 3 },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true },
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
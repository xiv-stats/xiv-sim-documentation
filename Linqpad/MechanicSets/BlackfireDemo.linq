<Query Kind="Statements">
  <Reference>D:\src\Unity\xiv-sim\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "BlackfireDemo";
var baseOutputPath = @"D:\src\Unity\xiv-sim";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"SnapshotDive",
		new MechanicProperties
		{
			isTargeted = false,
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
		"BahamutMechanics",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(14, 4),
			colorHtml = "#0a4d8b",
			visible = false,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Bahamut.png", colorHtml = "#0a4d8b", visualDuration = 5, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 2 },
					new ModifyMechanicEvent { referenceMechanicName = "SnapshotDive" },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#0a4d8b", visualDuration = 4, spawnOnPlayer = true, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), isBillboard = true },
					new WaitEvent { timeToWait = 3.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Megaflare Dive" },
							new KnockbackEffect { knockbackDistance = 10 },
						}
					},
					new SpawnMechanicEvent { referenceMechanicName = "BahamutMechanics2" }
				}
			}
		}
	},
	{
		"BahamutMechanics2",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "MegaflareTarget", targetingScheme =
						new UnionTargetingSchemes {
							targetingSchemes = new List<TargetingScheme> {
								new TargetSpecificPlayerIdsByClass {classType = PlayerClassType.Tank, targetIds = new List<int>{0} },
								new TargetSpecificPlayerIdsByClass {classType = PlayerClassType.Healer, targetIds = new List<int>{0} },
								new TargetSpecificPlayerIdsByClass {classType = PlayerClassType.Dps, targetIds = new List<int>{0, 1} },
							}
						}
					},
					new SpawnTargetedEvents
					{
						referenceMechanicName = "MegaflareStack",
						targetingScheme = new TargetRandomPlayers
						{
							numTargets = 0,                                    	                       // Get all players in a random order
							targetCondition = new CheckPlayerStatus { statusName = "MegaflareMark" },  // Filter to only players marked by megaflare
							totalTargetsNeeded = 1,                                                    // Select one of the players to place the stack on
						}
					},
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
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Nael.png", colorHtml = "#a917bf", visualDuration = float.PositiveInfinity, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 4.9f },
					new SpawnTargetedEvents { referenceMechanicName = "Stack", spawnOnTarget = true, isPositionRelative = true, targetingScheme = new TargetRandomPlayers() },
					new WaitEvent { timeToWait = 8 },
					new SpawnTargetedEvents { referenceMechanicName = "Hypernova", spawnOnTarget = true, isPositionRelative = true, targetingScheme = new TargetRandomPlayers() },
					new WaitEvent { timeToWait = 1.6f },
					new SpawnTargetedEvents { referenceMechanicName = "Hypernova", spawnOnTarget = true, isPositionRelative = true, targetingScheme = new TargetRandomPlayers() },
					new WaitEvent { timeToWait = 1.6f },
					new SpawnTargetedEvents { referenceMechanicName = "Hypernova", spawnOnTarget = true, isPositionRelative = true, targetingScheme = new TargetRandomPlayers() },
					new WaitEvent { timeToWait = 1.6f },
					new SpawnTargetedEvents { referenceMechanicName = "Hypernova", spawnOnTarget = true, isPositionRelative = true, targetingScheme = new TargetRandomPlayers() },
				}
			}
		}
	},
	{
		"Stack",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.4f, 360),
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
		"Hypernova",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#352a43",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Hypernova" } },
					new WaitEvent { timeToWait = 10 },
				}
			},

			persistentTickInterval = 0.3f,
			persistentActivationDelay = 2,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Bleed" } },
		}
	},
	{
		"TwinMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Twintania.png", colorHtml = "#067743", visualDuration = float.PositiveInfinity, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1.2f },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1.2f },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1.2f },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0 } } },
					new WaitEvent { timeToWait = 1.2f },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0 } } },
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
					new WaitEvent { timeToWait = 12 },
				}
			},
			persistentTickInterval = 0.3f,
			persistentActivationDelay = 3,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Burns" } },
		}
	},
	{
		"MegaflareTarget",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 4, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), isBillboard = true },
					new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = "MegaflareMark" } }
				}
			},
		}
	},
	{
		"MegaflareStack",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.68f, 360),
			colorHtml = "#ff4200",
			isTargeted = true,
			followSpeed = 10000,
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 5 },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "MegaflareMark" },
						effect = new DamageEffect { damageAmount = 350000, damageType = "Damage", name = "Megaflare", maxStackAmount = 4 },
						failedConditionEffect = new DamageEffect { damageAmount = 200000, damageType = "Damage", name = "Megaflare" },
					},
				}
			}
		}
	},
	{
		"SpawnTowers",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "Tower", isPositionRelative = true, isRotationRelative = true, position = new Vector2(3.5f, 0) },
					new SpawnMechanicEvent { referenceMechanicName = "Tower", isPositionRelative = true, isRotationRelative = true, position = new Vector2(-3.5f, 0) },
					new SpawnMechanicEvent { referenceMechanicName = "Tower", isPositionRelative = true, isRotationRelative = true, position = new Vector2(0, 3.5f) },
					new SpawnMechanicEvent { referenceMechanicName = "Tower", isPositionRelative = true, isRotationRelative = true, position = new Vector2(0, -3.5f) }
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
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Tower.png", colorHtml = "#FFFF00", visualDuration = 8, relativePosition = Vector3.up, scale = new Vector3(1, 1.8876f, 1) * 0.6f, eulerAngles = new Vector3(0, 0, 0) },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Tower.png", colorHtml = "#FFFF00", visualDuration = 8, relativePosition = Vector3.up, scale = new Vector3(1, 1.8876f, 1) * 0.6f, eulerAngles = new Vector3(0, 90, 0) },
					new WaitEvent { timeToWait = 8 },
					new CheckNumberOfPlayers
					{
						expressionFormat = "{0} >= 1",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "Tower Fail", isPositionRelative = true }
					},
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Megaflare" }
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
			collisionShapeParams = new Vector4(25, 360, 7),
			colorHtml = "#8800FF",
			persistentTickInterval = 0.2f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage" } },
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
					new WaitEvent { timeToWait = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "BahamutMechanics", position = new Vector2(0, 7), isPositionRelative = true, isRotationRelative = true, targetingScheme = new TargetRandomPlayers() },
					new SpawnMechanicEvent { referenceMechanicName = "TwinMechanics", position = new Vector2(-5, -5), isPositionRelative = true, isRotationRelative = true, rotation = 60 },
					new SpawnMechanicEvent { referenceMechanicName = "NaelMechanics", position = new Vector2(5, -5), isPositionRelative = true, isRotationRelative = true, rotation = -60 },
					new WaitEvent { timeToWait = 8 },
					new SpawnMechanicEvent { referenceMechanicName = "SpawnTowers", isRotationRelative = true },
				}
			}
		}
	},
	{
		"SpawnBossesB",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "BahamutMechanics", position = new Vector2(0, 7), isPositionRelative = true, isRotationRelative = true, targetingScheme = new TargetRandomPlayers() },
					new SpawnMechanicEvent { referenceMechanicName = "NaelMechanics", position = new Vector2(-5, -5), isPositionRelative = true, isRotationRelative = true, rotation = 60 },
					new SpawnMechanicEvent { referenceMechanicName = "TwinMechanics", position = new Vector2(5, -5), isPositionRelative = true, isRotationRelative = true, rotation = -60 },
					new WaitEvent { timeToWait = 8 },
					new SpawnMechanicEvent { referenceMechanicName = "SpawnTowers", isRotationRelative = true },
				}
			}
		}
	},
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"MegaflareMark",
		new StatusEffectData
		{
			statusName = "MegaflareMark",
			statusDescription = "Chosen to share the Megaflare stack.",
			duration = 7,
		}
	}
};

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"BossPool",
		new List<MechanicEvent> {
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses" },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 45 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 90 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 135 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 180 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 225 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 270 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 315 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBossesB" },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBossesB", rotation = 45 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBossesB", rotation = 90 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBossesB", rotation = 135 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBossesB", rotation = 180 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBossesB", rotation = 225 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBossesB", rotation = 270 },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBossesB", rotation = 315 },
		}
	}
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaCircle.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(15.8637f, 15.8637f, 1),
	},
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" },
	new ExecuteRandomEvents { mechanicPoolName = "BossPool" }
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
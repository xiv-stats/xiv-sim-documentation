<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "FellruinDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
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
		"BahamutMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 6 },
					new SpawnTethersToPlayers { referenceTetherName = "TempestWing", tetherOffset = new Vector3(0, 1, 0), targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1} } },
					new WaitEvent { timeToWait = 8 },
					new SpawnTargetedEvents { referenceMechanicName = "TetherAoe", targetingScheme = new TargetTetheredPlayers(), spawnOnTarget = true },
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide1" },
					new WaitEvent {timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
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
		"TetherAoe" ,
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#59ce85",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerIsMechanicTarget(),
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Tempest Wing" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Tempest Wing" },
							new KnockbackEffect { knockbackDistance = 10},
						}
					}
				}
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
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Neurolink" },
						effect = new DamageEffect { damageAmount = 80000, damageType = "Magic", name = "Aetheric Profusion" },
						failedConditionEffect = new DamageEffect { damageAmount = 800000, damageType = "Magic", name = "Aetheric Profusion" },
					}
				}
			}
		}
	},
	{
		"SpawnBosses-A",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnEnemy {
						enemyName = "Bahamut",
						textureFilePath = "Mechanics/Resources/Bahamut.png",
						colorHtml = "#0a4d8b",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 2,
						visualPosition = new Vector3(0, 1, 0),
						visualScale = Vector3.one,
						referenceMechanicName = "BahamutMechanics",
						position = new Vector2(0, -3.7f),
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
					},
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
						position = new Vector2(3.7f * 0.866f, 1.85f),
						rotation = 240,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false
					},
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
						position = new Vector2(-3.7f * 0.866f, 1.85f),
						rotation = 120,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false
					},
				}
			}
		}
	},
	{
		"SpawnBosses-B",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnEnemy {
						enemyName = "Bahamut",
						textureFilePath = "Mechanics/Resources/Bahamut.png",
						colorHtml = "#0a4d8b",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 2,
						visualPosition = new Vector3(0, 1, 0),
						visualScale = Vector3.one,
						referenceMechanicName = "BahamutMechanics",
						position = new Vector2(0, -3.7f),
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
					},
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
						position = new Vector2(-3.7f * 0.866f, 1.85f),
						rotation = 120,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false
					},
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
						position = new Vector2(3.7f * 0.866f, 1.85f),
						rotation = 240,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false
					},
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
					new WaitEvent { timeToWait = 2},
					new ExecuteRandomEvents { mechanicPoolName = "Spawn-Bosses-Pool" },
				}
			}
		}
	}
};

mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"TempestWing",
		new TetherProperties
		{
			colorHtml = "#00ff60",
			tetherDuration = 9,
			interceptMechanic = new SwitchTetheredPlayer(),
			oneTetherPerPlayer = true,
			tetherTag = "TempestWing",
			retargetRandomPlayerOnDeath = true
		}
	},
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
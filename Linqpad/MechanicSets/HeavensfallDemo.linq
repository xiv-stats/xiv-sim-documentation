<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "HeavensfallDemo";
var baseOutputPath = $@"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"Megaflare",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 360),
			colorHtml = "#FF4400",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Megaflare" } }
				}
			}
		}
	},
	{
		"HeavensfallDeathZone",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(2, 2.5f),
			colorHtml = "#0096ff",
			
			persistentTickInterval = 0.2f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "OutOfBounds" } },
			mechanic = new WaitEvent {timeToWait = 10}
		}
	},
	{
		"HeavensfallConeCW",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(7, 360 / 16f),
			colorHtml = "#FFFF00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new CheckMechanicDepth
					{
						expressionFormat = "{0} < 9",
						successEvent = new SpawnMechanicEvent { referenceMechanicName = "HeavensfallConeCW", rotation = 360 / 16f, isRotationRelative = true }
					},
					new WaitEvent { timeToWait = 2 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Heavensfall Cone" }
					}
				}
			}
		}
	},
	{
		"HeavensfallConeInitialCW",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(7, 360 / 16f),
			colorHtml = "#FFFF00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new SpawnMechanicEvent { referenceMechanicName = "HeavensfallConeCW", rotation = 360 / 16f, isRotationRelative = true },
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Heavensfall Cone" }
					}
				}
			}
		}
	},
	{
		"HeavensfallConeCCW",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(7, 360 / 16f),
			colorHtml = "#FFFF00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new CheckMechanicDepth
					{
						expressionFormat = "{0} < 9",
						successEvent = new SpawnMechanicEvent { referenceMechanicName = "HeavensfallConeCCW", rotation = -360 / 16f, isRotationRelative = true }
					},
					new WaitEvent { timeToWait = 2 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Heavensfall Cone" }
					}
				}
			}
		}
	},
	{
		"HeavensfallConeInitialCCW",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(7, 360 / 16f),
			colorHtml = "#FFFF00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new SpawnMechanicEvent { referenceMechanicName = "HeavensfallConeCCW", rotation = -360 / 16f, isRotationRelative = true },
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Heavensfall Cone" }
					}
				}
			}
		}
	},
	{
		"SpawnHeavensfallConesCW",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "HeavensfallConeInitialCW", isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "HeavensfallConeInitialCW", isRotationRelative = true, rotation = 180 },
				}
			}
		}
	},
	{
		"SpawnHeavensfallConesCCW",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "HeavensfallConeInitialCCW", isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "HeavensfallConeInitialCCW", isRotationRelative = true, rotation = 180 },
				}
			}
		}
	},
	{
		"SpawnHeavensfallCones",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ExecuteRandomEvents { mechanicPoolName = "HeavensfallConeDirectionPool" }
				}
			}
		}
	},
	{
		"Mechanics-B",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(14, 3),
			colorHtml = "#0a4d8b",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Bahamut.png", colorHtml = "#0a4d8b", visualDuration = 5, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 5 },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Divebomb" },
							new KnockbackEffect { knockbackDistance = 10 },
						}
					}
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
		"Mechanics-T",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(14, 3),
			colorHtml = "#067743",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Twintania.png", colorHtml = "#067743", visualDuration = 5, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "Twister",
						spawnOnTarget = true,
						targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2, 3 }, dropExtraEvents = true}
					},
					new WaitEvent { timeToWait = 2 },
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Divebomb" },
							new KnockbackEffect { knockbackDistance = 10 },
						}
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
		"Mechanics-N",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Nael.png", colorHtml = "#a917bf", visualDuration = 15, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 15 },
					new SpawnTargetedEvents {referenceMechanicName = "Hypernova", spawnOnTarget = true, targetingScheme = new TargetRandomPlayers() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents {referenceMechanicName = "Hypernova", spawnOnTarget = true, targetingScheme = new TargetRandomPlayers() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents {referenceMechanicName = "Hypernova", spawnOnTarget = true, targetingScheme = new TargetRandomPlayers() },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents {referenceMechanicName = "Hypernova", spawnOnTarget = true, targetingScheme = new TargetRandomPlayers() },
					new SpawnTargetedEvents {referenceMechanicName = "Fireball", spawnOnTarget = true, targetingScheme = new TargetRandomPlayers() },
				}
			}
		}
	},
	{
		"FireballVisible",
		new MechanicProperties
		{
			visible = true,
		}
	},
	{
		"Fireball",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#ff4200",
			isTargeted = true,
			followSpeed = 10000,
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 5, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 0, 0) },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 5, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 90, 0) },
					new WaitEvent { timeToWait = 4 },
					new ModifyMechanicEvent { referenceMechanicName = "FireballVisible" },
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 600000, damageType = "Damage", name = "Fireball", maxStackAmount = 8 } },
				}
			}
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
					new ExecuteRandomEvents { mechanicPoolName = "DivebombPool" },
				}
			}
		}
	},
	{
		"KnockbackFromCenter",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(15, 360),
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Heavensfall" },
							new KnockbackEffect { knockbackDistance = 4 },
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
			collisionShapeParams = new Vector4(0.75f, 360),
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
						expressionFormat = "{0} = 1",
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
			collisionShapeParams = new Vector4(15, 360, 7),
			colorHtml = "#8800FF",
			
			persistentTickInterval = 0.2f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "OutOfBounds" } },
		}
	}
};

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>();

var divebombPool = new List<MechanicEvent>();
mechanicData.mechanicPools["DivebombPool"] = divebombPool;

foreach (var spawnCombo in new List<string> { "TNB", "TBN", "BNT", "BTN", "NTB", "NBT" })
{
	var divebombsToSpawn = new ExecuteMultipleEvents();
	divebombsToSpawn.events = new List<MechanicEvent>();
	
	var angleOffset = 0f;
	
	if (spawnCombo[0] == 'N') {
		angleOffset = 7.5f;
	}
	else if (spawnCombo[2] == 'N') {
		angleOffset = -7.5f;
	}
	
	for (int i = -1; i <= 1; i++)
	{
		float a = (30 * i + angleOffset) * Mathf.Deg2Rad;
		float x = 7 * Mathf.Cos(a);
		float y = 7 * Mathf.Sin(a);

		var spawnId = spawnCombo[i + 1];

		divebombsToSpawn.events.Add(new SpawnMechanicEvent { referenceMechanicName = $"Mechanics-{spawnId}", position = new Vector2(x, y), rotation = -90 - a * Mathf.Rad2Deg, isPositionRelative = true, isRotationRelative = true });
	}

	mechanicData.referenceMechanicProperties[$"Mechanics-{spawnCombo}"] = new MechanicProperties
	{
		visible = false,
		mechanic = divebombsToSpawn
	};

	divebombPool.Add(new SpawnMechanicEvent { referenceMechanicName = $"Mechanics-{spawnCombo}", isPositionRelative = true, isRotationRelative = true });
}

var bossRotationPool = new List<MechanicEvent>();
mechanicData.mechanicPools["SpawnBossesRotationPool"] = bossRotationPool;

var heavensfallTowerPool = new List<MechanicEvent>();
mechanicData.mechanicPools["HeavensfallTowerPool"] = heavensfallTowerPool;

var heavensfallConePool = new List<MechanicEvent>();
mechanicData.mechanicPools["HeavensfallConePool"] = heavensfallConePool;

for (int i = 0; i < 16; i++)
{
	float a = 2 * Mathf.PI / 16 * i;
	float x = 7 * Mathf.Cos(a);
	float y = 7 * Mathf.Sin(a);
	bossRotationPool.Add(new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = a * Mathf.Rad2Deg });
	heavensfallConePool.Add(new SpawnMechanicEvent { referenceMechanicName = "SpawnHeavensfallCones", rotation = a * Mathf.Rad2Deg });
	heavensfallTowerPool.Add(new SpawnMechanicEvent { referenceMechanicName = "Tower", position = new Vector2(x, y) });
}

var heavensfallConeDirectionPool = new List<MechanicEvent>();
mechanicData.mechanicPools["HeavensfallConeDirectionPool"] = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "SpawnHeavensfallConesCW" },
	new SpawnMechanicEvent { referenceMechanicName = "SpawnHeavensfallConesCCW" }
};

var mechanicSequence = new List<MechanicEvent>{
	new WaitEvent {timeToWait = 3},
	new ExecuteRandomEvents { mechanicPoolName = "SpawnBossesRotationPool"},
	new WaitEvent {timeToWait = 5},
	new ExecuteRandomEvents { mechanicPoolName = "HeavensfallTowerPool", numberToSpawn = 8},
	new WaitEvent {timeToWait = 1},
	new ReshufflePlayerIds(),
	new SpawnTargetedEvents { referenceMechanicName = "Megaflare", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 } } },
	new WaitEvent {timeToWait = 4},
	new SpawnMechanicEvent { referenceMechanicName = "KnockbackFromCenter"},
	new SpawnMechanicEvent { referenceMechanicName = "HeavensfallDeathZone", position = new Vector2(0, -1)},
	new WaitEvent {timeToWait = 3},
	new ExecuteRandomEvents { mechanicPoolName = "HeavensfallConePool"},
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
	new ExecuteMultipleEvents { events = mechanicSequence }
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
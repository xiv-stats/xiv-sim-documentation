<Query Kind="Statements">
  <Reference>D:\src\Unity\xiv-sim\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "SuppressionDemo";
var baseOutputPath = @"D:\src\Unity\xiv-sim";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

var eruptionTargets = new TargetSpecificPlayerIdsByClass
{
	classType = PlayerClassType.Tank,
	invertCheck = true,
	targetIds = new List<int> { 0, 1, 2 }	
};

var gaolTarget = new TargetSpecificPlayerIdsByClass
{
	classType = PlayerClassType.Tank,
	invertCheck = true,
	targetIds = new List<int> { 0 }
};

var mistralSongTarget1 = new TargetSpecificPlayerIdsByClass
{
	classType = PlayerClassType.Tank,
	invertCheck = true,
	targetIds = new List<int> { 3 }
};

var mistralSongTarget2 = new TargetSpecificPlayerIdsByClass
{
	classType = PlayerClassType.Tank,
	invertCheck = true,
	targetIds = new List<int> { 4 }
};

var lightPillarTarget = new TargetSpecificPlayerIdsByClass
{
	classType = PlayerClassType.Tank,
	invertCheck = true,
	targetIds = new List<int> { 5 }
};

var cycloneTarget = new TargetSpecificProximityPlayers
{
	useWildChargeDistanceFormula = true,
	onlyIncludeTargetsInAoeHitbox = true,
	targetIds = new List<int> { 0 }
};

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"GarudaMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 7 },
					new SetEnemyMovement { moveToTarget = new TargetRandomPlayers { numTargets = 1 }, movementTime = -5 },
					new WaitEvent { timeToWait = 0.5f },
					new SpawnMechanicEvent { referenceMechanicName = "GarudaCone", isPositionRelative = true, isRotationRelative = true },
					new WaitEvent { timeToWait = 1.5f },
					new SpawnMechanicEvent { referenceMechanicName = "SpawnFeatherlance" },
					new StartCastBar { castName = "AH hA heE Ha HA", duration = 1 },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpawnFeatherRain", spawnOnTarget = true, targetingScheme = new TargetAllPlayers() },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "AH hA heE Ha HA", duration = 1 },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpawnFeatherRain", spawnOnTarget = true, targetingScheme = new TargetAllPlayers() },

					new WaitEvent { timeToWait = 8 },
					new SpawnTethersToPlayers { referenceTetherName = "Mesohigh", tetherOffset = new Vector3(0, 2, 0), targetingScheme = new TargetRandomPlayers {numTargets = 1} },

					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Mesohigh", targetingScheme = new TargetTetheredPlayers(), spawnOnTarget = true },

					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "AH hA heE Ha HA", duration = 1 },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpawnFeatherRain", spawnOnTarget = true, targetingScheme = new TargetAllPlayers() },

					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"Sister-1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 4 },
					new SpawnTargetedEvents { referenceMechanicName = "MistralSong", isPositionRelative = true, targetingScheme = mistralSongTarget1 },
					new WaitEvent { timeToWait = 5 }
				}
			}
		}
	},
	{
		"Sister-2",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 4 },
					new SpawnTargetedEvents { referenceMechanicName = "MistralSong", isPositionRelative = true,  targetingScheme = mistralSongTarget2 },
					new WaitEvent { timeToWait = 5 }
				}
			}
		}
	},
	{
		"IfritMechanics",
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
		"TitanMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 19.5f },
					new SetEnemyMovement { moveToTarget = new TargetRandomPlayers { numTargets = 1 }, movementTime = -5 },
					new WaitEvent { timeToWait = 0.5f },
					new SpawnMechanicEvent { referenceMechanicName = "Landslide", isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "Landslide", isPositionRelative = true, isRotationRelative = true, rotation = 45 },
					new SpawnMechanicEvent { referenceMechanicName = "Landslide", isPositionRelative = true, isRotationRelative = true, rotation = -45 },
					
					new WaitEvent { timeToWait = 4 },
					
					new SpawnMechanicEvent { referenceMechanicName = "Landslide-Fast", isPositionRelative = true, isRotationRelative = true, rotation = 22.5f },
					new SpawnMechanicEvent { referenceMechanicName = "Landslide-Fast", isPositionRelative = true, isRotationRelative = true, rotation = -22.5f },
					new SpawnMechanicEvent { referenceMechanicName = "Landslide-Fast", isPositionRelative = true, isRotationRelative = true, rotation = 67.5f },
					new SpawnMechanicEvent { referenceMechanicName = "Landslide-Fast", isPositionRelative = true, isRotationRelative = true, rotation = -67.5f },

					new WaitEvent {timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"UltimaMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "Eruption", spawnOnTarget = true, targetingScheme = eruptionTargets, resetMechanicDepth = true },
					
					new WaitEvent { timeToWait = 4 }, // 3rd Eruption
					new SpawnTargetedEvents { referenceMechanicName = "SelectGaolTarget", targetingScheme = gaolTarget },

					new WaitEvent { timeToWait = 2 },
					new StartCastBar { castName = "Light Pillar", duration = 2 },
					new WaitEvent { timeToWait = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "LightPillar", spawnOnTarget = true, targetingScheme = lightPillarTarget, resetMechanicDepth = true },
					new WaitEvent { timeToWait = 2 },
					
					new ExecuteRandomEventSequence { mechanicPoolName = "UltimaLaser-Pool", mechanicIndex = 0 },
					new WaitEvent { timeToWait = 4 },
					new ExecuteRandomEventSequence { mechanicPoolName = "UltimaLaser-Pool", mechanicIndex = 1 },
					new WaitEvent { timeToWait = 4 },
					new ExecuteRandomEventSequence { mechanicPoolName = "UltimaLaser-Pool", mechanicIndex = 2 },

					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "FlamingCrush", targetingScheme = new TargetSpecificPlayerIdsByClass { invertCheck = true, classType = PlayerClassType.Tank, targetIds = new List<int> {0} } },
					
					new WaitEvent { timeToWait = 6 },

					new StartCastBar { castName = "Tank Purge", duration = 4 },
					new WaitEvent { timeToWait = 4 },
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide" },
					
					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"Eruption",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2.5f, 360),
			colorHtml = "#ff4200",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2f },
					new CheckMechanicDepth {
						expressionFormat = "{0} < 3",
						successEvent = new SpawnTargetedEvents { referenceMechanicName = "Eruption", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() }
					},
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Eruption" }
					}
				}
			}
		}
	},
	{
		"FlamingCrush",
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
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 4, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), isBillboard = true },
					new WaitEvent { timeToWait = 5 },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 700000, damageType = "Damage", name = "Flaming Crush", maxStackAmount = 8 } },
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
		"MistralSong",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(20, 1),
			colorHtml = "#00ff6c",
			visible = false,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#00ff6c", visualDuration = 4, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), isBillboard = true },
					new WaitEvent { timeToWait = 3.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new WildChargeDamageEffect { damageAmountFront = 200000, damageAmountBack = 40000, damageType = "Magic", name = "Mistral Song" },
						}
					},
					new SpawnTargetedEvents { referenceMechanicName = "Cyclone", spawnOnTarget = true, targetingScheme = cycloneTarget }
				}
			}
		}
	},
	{
		"Cyclone-Active",
		new MechanicProperties
		{
			colorHtml = "#0d9d1e"
		}
	},
	{
		"Cyclone",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2.7f, 360),
			colorHtml = "#0d9d1e55",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 4 },
					new ModifyMechanicEvent { referenceMechanicName = "Cyclone-Active" },
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 800000, damageType = "Damage", name = "Great Whirlwind" } },
					new WaitEvent { timeToWait = 2 },
				}
			},
		}
	},
	{
		"GarudaCone",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(8, 120),
			colorHtml = "#00ff6c",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1.5f },
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 200000, damageType = "Damage", name = "Mistral Song" } }
				}
			}
		}
	},
	{
		"SpawnFeatherRain",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "FeatherRain", isPositionRelative = true },
				}
			}
		}
	},
	{
		"FeatherRain",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1 },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 35000, damageType = "Damage", name = "Feather Rain" },
							new ApplyStatusEffect { referenceStatusName = "Windburn" }
						}
					}
				}
			}
		}
	},
	{
		"Mesohigh" ,
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.5f, 360),
			colorHtml = "#59ce85",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Thermal Low" },
						effects = new List<MechanicEffect>
						{
							new RemoveStatusEffect { referenceStatusName = "ThermalLow", doExpireEvent = true },
							new DamageEffect { damageAmount = 20000, damageType = "Damage", name = "Mesohigh" },
						},
						failedConditionEffect = new DamageEffect { damageAmount = 500000, damageType = "Damage", name = "Mesohigh" }
					}
				}
			}
		}
	},
	{
		"ClearFeatherlances",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "SuperCyclone" },
					new ClearMechanicsWithTag { mechanicTag = "Featherlance" }
				}
			}
		}
	},
	{
		"SuperCyclone",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Super Cyclone" }
			}
		}
	},
	{
		"GaolMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents { referenceMechanicName = "ApplyFetters", targetingScheme = gaolTarget },
					new StartCastBar { castName = "Granite Impact", duration = 7 },
					new WaitEvent { timeToWait = 7 },
					new SpawnMechanicEvent { referenceMechanicName = "GraniteImpact", isPositionRelative = true, isRotationRelative = true },
					new WaitEvent { timeToWait = float.PositiveInfinity },
				}
			}
		}
	},
	{
		"ApplyFetters",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "Fetters" }
			}
		}
	},
	{
		"RemoveFetters",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new RemoveStatusEffect { referenceStatusName = "Fetters" }
			}
		}
	},
	{
		"RemoveFettersFromTarget",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnTargetedEvents { referenceMechanicName = "RemoveFetters", targetingScheme = gaolTarget }
		}
	},
	{
		"GraniteImpact",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage", name = "Granite Impact" }
			}
		}
	},
	{
		"SelectGaolTarget",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#f0ba00", visualDuration = 2, spawnOnPlayer = true, relativePosition = Vector3.up * 0.6f, scale = new Vector3(0.8f, 0.8f, 1), isBillboard = true },
					new WaitEvent { timeToWait = 1.95f },
					new SpawnTargetedEvents { referenceMechanicName = "SpawnGaol", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() }
				}
			}
		}
	},
	{
		"SpawnGaol",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Granite Gaol",
				textureFilePath = "Mechanics/Resources/Gaol.png",
				colorHtml = "#885300",
				maxHp = 150000,
				baseMoveSpeed = 0,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 1, 0),
				visualScale = Vector3.one * 2,
				referenceMechanicName = "GaolMechanics",
				deathMechanicName = "RemoveFettersFromTarget",
				isPositionRelative = true,
				isRotationRelative = true,
			}
		}
	},
	{
		"LightPillarFollow",
		new MechanicProperties
		{
			followSpeed = 1.5f
		}
	},
	{
		"LightPillar",
		new MechanicProperties
		{
			visible = false,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ModifyMechanicEvent { referenceMechanicName = "LightPillarFollow" },
					new SpawnMechanicEvent { referenceMechanicName = "LightPillarAoe", isPositionRelative = true },
					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "LightPillarAoe", isPositionRelative = true },
					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "LightPillarAoe", isPositionRelative = true },
					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "LightPillarAoe", isPositionRelative = true },
					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "LightPillarAoe", isPositionRelative = true },
					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "LightPillarAoe", isPositionRelative = true },
				}
			}
		}
	},
	{
		"LightPillarAoe",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#71f3ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Light Pillar" }
					}
				}
			}
		}
	},
	{
		"UltimaLaser",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(40, 3.5f),
			colorHtml = "#71f3ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Aetherochemical Laser" }
					}
				}
			}
		}
	},
	{
		"Raidwide",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 125000, damageType = "Damage", name = "Tank Purge" }
			}
		}
	},
	{
		"Landslide",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(40, 2.5f),
			colorHtml = "#ff7e00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Landslide" },
							new KnockbackEffect { knockbackDistance = 10 }
						}
					}
				}
			}
		}
	},
	{
		"Landslide-Fast",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(40, 2.5f),
			colorHtml = "#ff7e00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Landslide" },
							new KnockbackEffect { knockbackDistance = 10 }
						}
					}
				}
			}
		}
	},
	{
		"FeatherlanceExplode",
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
						effect = new DamageEffect { damageAmount = 320000, damageType = "Damage", name = "Featherlance" },
					}
				}
			}
		}
	},
	{
		"FeatherlanceExplode2",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(10, 360),
			colorHtml = "#008542",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 320000, damageType = "Damage", name = "Featherlance" },
					}
				}
			}
		}
	},
	{
		"SpawnFeatherlance",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEventsParallel
			{
				events = new List<MechanicEvent>
				{
					new SpawnEnemy {
						enemyName = "Featherlance",
						textureFilePath = "Mechanics/Resources/Featherlance.png",
						colorHtml = "#00ff60",
						maxHp = 35000000,
						hitboxSize = 1,
						visualPosition = new Vector3(0, 1, 0),
						visualScale = Vector3.one * 0.5f,
						referenceMechanicName = "Featherlance-0",
						isTargetable = false,
						showInEnemyList = false,
					},
					new SpawnEnemy {
						enemyName = "Featherlance",
						textureFilePath = "Mechanics/Resources/Featherlance.png",
						colorHtml = "#00ff60",
						maxHp = 35000000,
						hitboxSize = 1,
						visualPosition = new Vector3(0, 1, 0),
						visualScale = Vector3.one * 0.5f,
						referenceMechanicName = "Featherlance-1",
						isTargetable = false,
						showInEnemyList = false,
					},
					new SpawnEnemy {
						enemyName = "Featherlance",
						textureFilePath = "Mechanics/Resources/Featherlance.png",
						colorHtml = "#00ff60",
						maxHp = 35000000,
						hitboxSize = 1,
						visualPosition = new Vector3(0, 1, 0),
						visualScale = Vector3.one * 0.5f,
						referenceMechanicName = "Featherlance-2",
						isTargetable = false,
						showInEnemyList = false,
					},
					new SpawnEnemy {
						enemyName = "Featherlance",
						textureFilePath = "Mechanics/Resources/Featherlance.png",
						colorHtml = "#00ff60",
						maxHp = 35000000,
						hitboxSize = 1,
						visualPosition = new Vector3(0, 1, 0),
						visualScale = Vector3.one * 0.5f,
						referenceMechanicName = "Featherlance-3",
						isTargetable = false,
						showInEnemyList = false,
					},
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
					new WaitEvent { timeToWait = 3 },
					new SpawnEnemy {
						enemyName = "Ultima Weapon",
						textureFilePath = "Mechanics/Resources/UltimaWeapon.png",
						colorHtml = "#0072ff",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 4,
						visualPosition = new Vector3(0, 2, 0),
						visualScale = Vector3.one * 4,
						referenceMechanicName = "UltimaMechanics",
						position = new Vector2(5, 5),
						rotation = 225,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
					},
					new SpawnEnemy {
						enemyName = "Garuda",
						textureFilePath = "Mechanics/Resources/Garuda.png",
						colorHtml = "#00ff60",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 2,
						visualPosition = new Vector3(0, 2, 0),
						visualScale = new Vector3(1.66f, 1, 1) * 2,
						referenceMechanicName = "GarudaMechanics",
						position = new Vector2(-5, 5),
						rotation = 135,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false
					},
					new SpawnEnemy {
						enemyName = "Ifrit",
						textureFilePath = "Mechanics/Resources/Ifrit.png",
						colorHtml = "#ff0000",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 2,
						visualPosition = new Vector3(0, 2, 0),
						visualScale = Vector3.one * 4,
						referenceMechanicName = "IfritMechanics",
						position = new Vector2(5, -5),
						rotation = -45,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
						showInEnemyList = false,
					},
					new SpawnEnemy {
						enemyName = "Titan",
						textureFilePath = "Mechanics/Resources/Titan.png",
						colorHtml = "#885300",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 2,
						visualPosition = new Vector3(0, 2, 0),
						visualScale = Vector3.one * 4,
						referenceMechanicName = "TitanMechanics",
						position = new Vector2(-5, -5),
						rotation = 45,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
						showInEnemyList = false,
					},
					new SpawnEnemy {
						enemyName = "Suparna",
						textureFilePath = "Mechanics/Resources/Garuda.png",
						colorHtml = "#00ff60",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 2,
						visualPosition = new Vector3(0, 1, 0),
						visualScale = new Vector3(1.66f, 1, 1) * 0.5f,
						referenceMechanicName = "Sister-1",
						position = new Vector2(-3.33f, 3.33f) * 0.5f,
						rotation = 135,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
						showInEnemyList = false,
					},
					new SpawnEnemy {
						enemyName = "Chirada",
						textureFilePath = "Mechanics/Resources/Garuda.png",
						colorHtml = "#00ff60",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 2,
						visualPosition = new Vector3(0, 1, 0),
						visualScale = new Vector3(1.66f, 1, 1) * 0.5f,
						referenceMechanicName = "Sister-2",
						position = new Vector2(3.33f, -3.33f) * 0.5f,
						rotation = -45,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
						showInEnemyList = false,
					},
				}
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
			persistentMechanic = new CheckNumberOfPlayers
			{
				expressionFormat = "{0} = 0",
				failEvent = new ExecuteMultipleEvents{
					events = new List<MechanicEvent> {
						new ApplyEffectToPlayers { effect = new ApplyStatusEffect { referenceStatusName = "ThermalLow" } },
						new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses" },
						new EndMechanic()
					}
				}
			},
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

for (int i = 0; i < 4; i++)
{
	mechanicData.referenceMechanicProperties[$"Featherlance-{i}"] = new MechanicProperties
	{
		visible = false,
		mechanicTag = "Featherlance",
		mechanic = new ExecuteMultipleEvents
		{
			events = new List<MechanicEvent>
			{
				new SetEnemyMovementPath { path = new CircleMovementPath { radius = 6.5f, degreesPerSecond = 45, startAngle = 90 * i } },
				new SpawnTethersToPlayers { referenceTetherName = "FeatherlanceDistance", targetingScheme = new TargetAllPlayers() },
				new WaitEvent { timeToWait = 18 },
				new SpawnMechanicEvent { referenceMechanicName = "FeatherlanceExplode2", isPositionRelative = true },
			}
		}
	};
}

mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"FeatherlanceDistance",
		new TetherProperties
		{
			visible = false,
			persistentActivationDelay = 2,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = 0.5f,
				maxDistance = float.PositiveInfinity,
				failEvent = new ExecuteMultipleTetherEvents {
					events = new List<TetherEvent>
					{
						new SpawnMechanicAtSource { referenceMechanicName = "FeatherlanceExplode" },
						new EndTether(),
						new EndSourceMechanic(),
					}
				}
			}
		}
	},
	{
		"Mesohigh",
		new TetherProperties
		{
			colorHtml = "#00ff60",
			tetherDuration = 5.5f,
			interceptMechanic = new SwitchTetheredPlayer(),
			retargetRandomPlayerOnDeath = true
		}
	},
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"Fetters",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/Fetters.png",
			statusName = "Fetters",
			statusDescription = "Unable to execute actions.",
			duration = float.PositiveInfinity,
			disableType = DisableType.Actions | DisableType.Damage | DisableType.Knockback | DisableType.Movement | DisableType.Statuses
		}
	},
	{
		"ThermalLow",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/ThermalLow.png",
			statusName = "Thermal Low",
			statusDescription = "The wind is high.",
			duration = float.PositiveInfinity,
			shouldKeepOnDeath = true,
			referenceMechanicName = "ClearFeatherlances",
		}
	},
	{
		"Windburn",
		new DamageOverTime
		{
			statusIconPath = "Mechanics/Resources/Windburn.png",
			statusName = "Windburn",
			statusDescription = "Sustaining wind damage over time.",
			duration = 18,
			tickInterval = 3,
			damageAmount = 45000,
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
			new SpawnMechanicEvent { referenceMechanicName = "StartButton", position = new Vector2(0, 3) },
		}
	}
};

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"UltimaLaser-Pool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent { referenceMechanicName = "UltimaLaser", isPositionRelative = true, isRotationRelative = true },
			new SpawnMechanicEvent { referenceMechanicName = "UltimaLaser", isPositionRelative = true, isRotationRelative = true, rotation = 45 },
			new SpawnMechanicEvent { referenceMechanicName = "UltimaLaser", isPositionRelative = true, isRotationRelative = true, rotation = -45 },
		}
	},
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
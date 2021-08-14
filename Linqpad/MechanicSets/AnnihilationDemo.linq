<Query Kind="Statements">
  <Reference Relative="..\..\..\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll">D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "AnnihilationDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();


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
					new WaitEvent { timeToWait = 5.1f },
					new SpawnMechanicEvent { referenceMechanicName = "EyeOfTheStorm", position = new Vector2(0, 0) },
					new SpawnTethersToPlayers { referenceTetherName = "Mesohigh", tetherOffset = new Vector3(0, 1, 0), targetingScheme = new TargetRandomPlayers {numTargets = 1} },
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Mesohigh", targetingScheme = new TargetTetheredPlayers(), spawnOnTarget = true },
					new WaitEvent { timeToWait = 1.6f },
					new StartCastBar { castName = "AH hA heE Ha HA", duration = 1 },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpawnFeatherRain", spawnOnTarget = true, targetingScheme = new TargetRandomPlayers {numTargets = 5} },
					new WaitEvent { timeToWait = 8.4f },
					new SpawnMechanicEvent { referenceMechanicName = "EyeOfTheStorm", position = new Vector2(0, 0) },
					new SpawnTethersToPlayers { referenceTetherName = "Mesohigh", tetherOffset = new Vector3(0, 1, 0), targetingScheme = new TargetRandomPlayers {numTargets = 1} },
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Mesohigh", targetingScheme = new TargetTetheredPlayers(), spawnOnTarget = true },
					new WaitEvent { timeToWait = 1.6f },
					new StartCastBar { castName = "AH hA heE Ha HA", duration = 1 },
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "SpawnFeatherRain", spawnOnTarget = true, targetingScheme = new TargetRandomPlayers {numTargets = 5} },

					new WaitEvent { timeToWait = float.PositiveInfinity }
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
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Ifrit.png", colorHtml = "#ff0000", visualDuration = 19.3f, relativePosition = Vector3.up, scale = new Vector3(2, 2, 2), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent {timeToWait = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "FlamingCrush", targetingScheme = new TargetSpecificPlayerIdsByClass { invertCheck = true, classType = PlayerClassType.Tank, targetIds = new List<int> {0} } },
					new WaitEvent {timeToWait = 9.1f },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "ApplySearingWind", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Healer, targetIds = new List<int> {0} } },
					new WaitEvent {timeToWait = 4.6f },
					new SpawnMechanicEvent { referenceMechanicName = "IfritDash", isPositionRelative = true, isRotationRelative = true },
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
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Titan.png", colorHtml = "#885300", visualDuration = 25, relativePosition = Vector3.up, scale = new Vector3(2, 2, 2), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 2 },
					new SpawnTargetedEvents { referenceMechanicName = "WeightOfTheLand", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 } }, resetMechanicDepth = true } ,
					new WaitEvent { timeToWait = 15.2f },
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
					new SpawnTargetedEvents { referenceMechanicName = "SetHealerThermals", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Healer, targetIds = new List<int> {0, 1} } },
					new SetEnemyMovement { movementTime = float.NegativeInfinity },
					new ExecuteRandomEvents { mechanicPoolName = "IfritTitanPool"},
					new WaitEvent { timeToWait = 7.5f },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "Aetheroplasm", position = new Vector2(1.5f, 2), targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {0} } },
					new WaitEvent { timeToWait = 6.1f },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "Aetheroplasm", position = new Vector2(1.5f, 2), targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {0} } },
					new WaitEvent { timeToWait = 6.1f },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "Aetheroplasm", position = new Vector2(1.5f, 2), targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {0} } },
					new WaitEvent { timeToWait = 6.1f },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "Aetheroplasm", position = new Vector2(1.5f, 2), targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {0} } },
					new StartCastBar { castName = "Tank Purge", duration = 4 },
					new WaitEvent { timeToWait = 4 },
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide" },
					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"WeightOfTheLand",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 360),
			colorHtml = "#6e4703",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Weight of the Land" }
					},
					new CheckMechanicDepth {
						expressionFormat = "{0} < 2",
						successEvent = new SpawnTargetedEvents { referenceMechanicName = "WeightOfTheLand", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() }
					},
				}
			}
		}
	},
	{
		"EyeOfTheStorm",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(25, 360, 4.5f),
			colorHtml = "#0a4d8b",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Eye of the Storm" },
							new KnockbackEffect { knockbackDistance = -3 },
						}
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
		"SetInvisible",
		new MechanicProperties
		{
			visible = false
		}
	},
	{
		"SpawnFeatherRain",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#ff9600",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1.6f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.4f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 70000, damageType = "Damage", name = "Feather Rain" },
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
		"TickSearingWind",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(3.6f, 360),
			colorHtml = "#db2100",
			isTargeted = true,
			followSpeed = 10000,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							statusName = "Searing Wind",
						},
						effects = new List<MechanicEffect> {},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 130000, damageType = "Damage", name = "Searing Wind" },
							new KnockbackEffect { knockbackDistance = 4 },
						}
					},
				}
			}
		}
	},
	{
		"ApplySearingWind",
		new MechanicProperties
		{
			visible = false,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents { referenceMechanicName = "SetSearing", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 6 },
					new SpawnTargetedEvents { referenceMechanicName = "TickSearingWind", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 6 },
					new SpawnTargetedEvents { referenceMechanicName = "TickSearingWind", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 6 },
					new SpawnTargetedEvents { referenceMechanicName = "TickSearingWind", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 6 },
					new SpawnTargetedEvents { referenceMechanicName = "TickSearingWind", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 6 },
					new SpawnTargetedEvents { referenceMechanicName = "TickSearingWind", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
				}
			}
		}
	},
	{
		"IfritLeft",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "IfritMechanics", position = new Vector2(-4.95f, -4.95f), rotation = 45 },
					new SpawnMechanicEvent { referenceMechanicName = "TitanMechanics", position = new Vector2(4.95f, -4.95f), rotation = -45 },
				}
			}
		}
	},
	{
		"IfritRight",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "TitanMechanics", position = new Vector2(-4.95f, -4.95f), rotation = 45 },
					new SpawnMechanicEvent { referenceMechanicName = "IfritMechanics", position = new Vector2(4.95f, -4.95f), rotation = -45 },
				}
			}
		}
	},
	{
		"IfritDash",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(14, 5),
			colorHtml = "#db2100",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 180000, damageType = "Damage", name = "Crimson Cyclone" },
						}
					},
					new ModifyMechanicEvent { referenceMechanicName = "SetInvisible" },
					new WaitEvent { timeToWait = 2.2f },
					new SpawnMechanicEvent { referenceMechanicName = "IfritAfterburn", position = new Vector2(0, -7), rotation = 0 },
					new SpawnMechanicEvent { referenceMechanicName = "IfritAfterburn", position = new Vector2(-7, 0), rotation = 90 },
				}
			}
		}
	},
	{
		"IfritAfterburn",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(14, 4),
			colorHtml = "#db2100",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 180000, damageType = "Damage", name = "Crimson Cyclone" },
						}
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
		"AetheroplasmMove",
		new MechanicProperties {
			followSpeed = 0.8f,
		}
	},
	{
		"AetheroplasmExplode",
		new MechanicProperties {
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.6f, 360),
			colorHtml = "#a800ff",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 30000, damageType = "Magic", name = "Aetheroplasm" } }
				}
			},
		}
	},
	{
		"SetHealerThermals",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "ThermalLow" },
			},
		}
	},
	{
		"SetSearing",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SearingWind" },
			},
		}
	},
	{
		"Aetheroplasm",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.4f, 360),
			colorHtml = "#a880ff",
			isTargeted = true,
			followSpeed = 0,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1.5f },
					new ModifyMechanicEvent { referenceMechanicName = "AetheroplasmMove" },
					new WaitEvent { timeToWait = 8 },
					new SpawnMechanicEvent { referenceMechanicName = "AetheroplasmExplode", isPositionRelative = true },
				}
			},
			persistentTickInterval = 0.1f,
			persistentActivationDelay = 1.5f,
			persistentMechanic = new CheckNumberOfPlayers
			{
				expressionFormat = "{0} = 0",
				failEvent = new ExecuteMultipleEvents {
					events = new List<MechanicEvent>
					{
						new SpawnMechanicEvent { referenceMechanicName = "AetheroplasmExplode", isPositionRelative = true },
						new EndMechanic()
					}
				},
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
		"SpawnBosses",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new SpawnEnemy {
						enemyName = "Ultima Weapon",
						textureFilePath = "Mechanics/Resources/UltimaWeapon.png",
						colorHtml = "#0072ff",
						maxHp = 35000000,
						baseMoveSpeed = 0,
						hitboxSize = 6,
						visualPosition = new Vector3(0, 2, 0),
						visualScale = Vector3.one * 4,
						referenceMechanicName = "UltimaMechanics",
						position = new Vector2(0, 3.5f),
						rotation = 180,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = true,
					},
						new SpawnEnemy {
						enemyName = "Garuda",
						textureFilePath = "Mechanics/Resources/Garuda.png",
						colorHtml = "#00ff60",
						maxHp = 35000000,
						baseMoveSpeed = 2,
						hitboxSize = 2,
						visualPosition = new Vector3(0, 1, 0),
						visualScale = new Vector3(1.66f, 1, 1) * 1.3f,
						referenceMechanicName = "GarudaMechanics",
						position = new Vector2(0, -7),
						rotation = 0,
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
};
mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
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
		"ThermalLow",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/ThermalLow.png",
			statusName = "Thermal Low",
			statusDescription = "The wind is high.",
			duration = float.PositiveInfinity,
			shouldKeepOnDeath = true,
			referenceMechanicName = "SuperCyclone",
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
		{
		"SearingWind",
		new DamageOverTime
		{
			statusIconPath = "Mechanics/Resources/SearingWind.png",
			statusName = "Searing Wind",
			statusDescription = "Ignited by white-hot embers and scorching those nearby. Sustaining fire damage over time.",
			duration = 31,
			tickInterval = 3,
			damageAmount = 20000,
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
		"IfritTitanPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent { referenceMechanicName = "IfritLeft", isPositionRelative = true, isRotationRelative = true },
			new SpawnMechanicEvent { referenceMechanicName = "IfritRight", isPositionRelative = true, isRotationRelative = true },
		}
	},
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();

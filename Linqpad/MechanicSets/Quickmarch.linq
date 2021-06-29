<Query Kind="Statements">
  <Reference Relative="..\..\..\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll">D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "QuickmarchDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"BahaDive",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(14, 4),
			colorHtml = "#0a4d8b",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Bahamut.png", colorHtml = "#0a4d8b", visualDuration = 5, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 4.3f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Megaflare Dive" },
							new KnockbackEffect { knockbackDistance = 10 },
						}
					}
				}
			}
		}
	},
	{
		"NaelDive",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(14, 4),
			colorHtml = "#a917bf",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Nael.png", colorHtml = "#a917bf", visualDuration = 5, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 4.3f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Raven Dive" },
							new KnockbackEffect { knockbackDistance = 10 },
						}
					}
				}
			}
		}
	},
	{
		"TwinDive",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(14, 4),
			colorHtml = "#067743",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Twintania.png", colorHtml = "#067743", visualDuration = 5, relativePosition = Vector3.up, scale = new Vector3(1, 1, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 4.3f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Twisting Dive" },
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
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
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
		"Megaflare",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents { referenceMechanicName = "MegaflarePuddles", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 } } },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "MegaflareStrikePending", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 } } },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "MegaflareTarget", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {0, 1, 2} } },
					new SpawnTargetedEvents { referenceMechanicName = "MegaflareStack", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {0} } },
					new SpawnTargetedEvents { referenceMechanicName = "MegaflareStackFake", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {1, 2} } }
				}
			}
		}
	},
	{
		"MegaflareTarget",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "MegaflareMark" }
			}
		}
	},
	{
		"MegaflarePuddles",
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
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Megaflare Puddle" } }
				}
			}
		}
	},
	{
		"MegaflareStack",
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
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 4, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 0, 0) },
					new WaitEvent { timeToWait = 5 },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							statusName = "Marked for Megaflare",
						},
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 200000, damageType = "Damage", name = "Megaflare Stack", maxStackAmount = 3 },
							new RemoveStatusEffect { referenceStatusName = "MegaflareMark" }
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 200000, damageType = "Damage", name = "Megaflare Stack" }
						}
					},
				}
			}
		}
	},
	{
		"MegaflareStackFake",
		new MechanicProperties
		{
			isTargeted = true,
			followSpeed = 10000,
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 4, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 0, 0) },
					new WaitEvent { timeToWait = 5 }
				}
			}
		}
	},
	{
		"MegaflareStrikePending" ,
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#dcdcdc",
			isTargeted = true,
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "MegaflareStrike", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() }
				}
			}
		}
	},
	{
		"MegaflareStrike" ,
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#dcdcdc",
			isTargeted = true,
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 80000, damageType = "Damage", name = "Megaflare AoE" }
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
					new WaitEvent { timeToWait = 4.8f },
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
		"SpawnBosses",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "BahaDive", isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "TwinDive", position = new Vector3(-2.5f, 0, 0), isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "NaelDive", position = new Vector3(2.5f, 0, 0), isPositionRelative = true, isRotationRelative = true }
				}
			}
		}
	},
	{
		"SpawnCenterBahamut",
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
						position = new Vector2(0, 0),
						rotation = 180,
						isRotationRelative = true,
						isTargetable = false,
					}
				}
			}
		}
	},
	{
		"BahamutMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new SpawnTargetedEvents { referenceMechanicName = "Earthshaker", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Healer, targetIds = new List<int> {0, 1} } },
					new SpawnTargetedEvents { referenceMechanicName = "Earthshaker", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> {3} } },
					new WaitEvent { timeToWait = 1 },
					new SpawnTethersToPlayers { referenceTetherName = "TempestWing", tetherOffset = new Vector3(0, 1, 0), targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1} } },
					new WaitEvent { timeToWait = 6 },
					new SpawnTargetedEvents { referenceMechanicName = "TetherAoe", targetingScheme = new TargetTetheredPlayers(), spawnOnTarget = true },
					new WaitEvent {timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
};

mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"TempestWing",
		new TetherProperties
		{
			colorHtml = "#00ff60",
			tetherDuration = 7,
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
	{
		"MegaflareMark",
		new StatusEffectData
		{
			statusName = "Marked for Megaflare",
			statusDescription = "Chosen to share the Megaflare stack.",
			duration = 7,
		}
	}
};

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>();
var startPool = new List<MechanicEvent>();
mechanicData.mechanicPools["StartPool"] = startPool;

for (int i = 0; i < 8; i++)
{
    float a = 2 * Mathf.PI / 8 * i;
    float x = 7 * Mathf.Cos(3 * Mathf.PI / 2 - a);
    float y = 7 * Mathf.Sin(3 * Mathf.PI / 2 - a);
	startPool.Add(new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = a * Mathf.Rad2Deg, position = new Vector2(x, y), isPositionRelative = true, isRotationRelative = true });
}

var mechanicSequence = new List<MechanicEvent>{
	new WaitEvent {timeToWait = 2},
	new ExecuteRandomEvents { mechanicPoolName = "StartPool"},
	new WaitEvent {timeToWait = 3.5f},
	new ReshufflePlayerIds(),
	new SpawnTargetedEvents { referenceMechanicName = "Twister", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 } } },
	new WaitEvent {timeToWait = 3},
	new ReshufflePlayerIds(),
	new SpawnMechanicEvent { referenceMechanicName = "Megaflare" },
	new WaitEvent {timeToWait = 2},
	new SpawnMechanicEvent { referenceMechanicName = "SpawnCenterBahamut"},
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
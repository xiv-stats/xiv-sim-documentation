<Query Kind="Statements">
  <Reference Relative="..\..\..\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll">D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "WrathOfTheHeavensDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

var target0 = new TargetSpecificPlayerIds { targetIds = new List<int>{0}};
var target1 = new TargetSpecificPlayerIds { targetIds = new List<int>{1}};
var target2 = new TargetSpecificPlayerIds { targetIds = new List<int>{2}};
var target3 = new TargetSpecificPlayerIds { targetIds = new List<int>{3}};

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"ThordanMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new StartCastBar { castName = "Wrath of the Heavens (short cast bar)", duration = 2 },
					
					new SpawnTargetedEvents { referenceMechanicName = "LightningDebuff-Delayed", targetingScheme = target0 },
					new SpawnTargetedEvents { referenceMechanicName = "LightningDebuff-Delayed", targetingScheme = target1 },

					new ReshufflePlayerIds(),
					new WaitEvent { timeToWait = 2 },
					
					new SetEnemyVisible { visible = false },
					new ExecuteRandomEvents { mechanicPoolName = "Adds1Pool" },
					new SpawnTargetedEvents { referenceMechanicName = "Defamation", spawnOnTarget = true, targetingScheme = target2 },
					
					new ExecuteRandomEvents { mechanicPoolName = "LiquidHellPool" },

					new WaitEvent { timeToWait = 5.8f },
					
					new SpawnTargetedEvents { referenceMechanicName = "DivebombTarget", targetingScheme = target3 },
					new WaitEvent { timeToWait = 0.2f },
					new SetEnemyVisible { visible = true },
					
					new WaitEvent { timeToWait = 2 },
					
					new StartCastBar { castName = "Ascalon's Mercy Revealed", duration = 3.3f },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "Protean", targetingScheme = new TargetAllPlayers() },
					
					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"SpawnAdds1",
		new MechanicProperties 
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "Spawn-Twintania", isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "Spawn-Knight1", isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "Spawn-Knight2", isPositionRelative = true, isRotationRelative = true },

					new WaitEvent { timeToWait = 4 },
					new SpawnMechanicEvent { referenceMechanicName = "Spawn-Dragon1", isPositionRelative = true, isRotationRelative = true },

					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "Spawn-Dragon2", isPositionRelative = true, isRotationRelative = true },
					new ExecuteRandomEvents { mechanicPoolName = "Adds2Pool" }
				}
			}
		}
	},
	{
		"LightningDebuff-Delayed",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 6 },
					new ApplyEffectToTargetOnly
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 40000, damageType = "Damage", name = "Chain Lightning" },
							new ApplyStatusEffect { referenceStatusName = "Lightning" }
						}
					},
					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"LiquidHellSequence",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 13 },

					new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = "LiquidHellTarget" }},
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 1.2f },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 1.2f },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 1.2f },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 1.2f },
					new SpawnTargetedEvents { referenceMechanicName = "Liquid Hell", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
					
					new WaitEvent { timeToWait = float.PositiveInfinity }
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
					new StartCastBar { castName = "Twisting Dive", duration = 6 }, // 00:04
					new SpawnMechanicEvent
					{
						referenceMechanicName = "Divebomb",
						isPositionRelative = true,
						isRotationRelative = true,
						position = new Vector3(0, 13.33f, 0),
						rotation = 180
					},
					new WaitEvent { timeToWait = 13 },
				}
			}
		}
	},
	{
		"Knight1-Mechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents
					{
						referenceMechanicName = "SpiralThrust",
						isPositionRelative = true,
						isRotationRelative = true,
						targetingScheme = target0
					},
					new SpawnTethersToPlayers { referenceTetherName = "SpiralThrustTether", targetingScheme = target0, tetherOffset = Vector3.up * 0.5f },
					new WaitEvent { timeToWait = 6 }
				}
			}
		}
	},
	{
		"Knight2-Mechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents
					{
						referenceMechanicName = "SpiralThrust",
						isPositionRelative = true,
						isRotationRelative = true,
						targetingScheme = target1
					},
					new SpawnTethersToPlayers { referenceTetherName = "SpiralThrustTether", targetingScheme = target1, tetherOffset = Vector3.up * 0.5f },
					new WaitEvent { timeToWait = 6 }
				}
			}
		}
	},
	{
		"Knight3-Mechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 6.3f },
					new SetEnemyAggro { aggroAmount = 100, targetingScheme = new TargetAllPlayers {
						targetCondition = new CheckPlayerStatus
						{
							invertStatus = true,
							statusName = "LiquidHellTarget"
						}
					}},
					
					new StartCastBar { castName = "Altar Flare", duration = 3.5f },
					new SpawnTargetedEvents { referenceMechanicName = "Altar Flare", spawnOnTarget = true, targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1.75f },
					new SpawnTargetedEvents { referenceMechanicName = "Altar Flare", spawnOnTarget = true, targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1.75f },
					new SpawnTargetedEvents { referenceMechanicName = "Altar Flare", spawnOnTarget = true, targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1.75f },
					new SpawnTargetedEvents { referenceMechanicName = "Altar Flare", spawnOnTarget = true, targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 6 }
				}
			}
		}
	},
	{
		"Knight4-Mechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 10 },
					new StartCastBar { castName = "Empty Dimension", duration = 5 },
					new WaitEvent { timeToWait = 4.8f },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true }
				}
			}
		}
	},
	{
		"Dragon1-Mechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 7.3f },
					new SetEnemyMovement
					{
						movementTime = -0.5f,
						moveToTarget = target3
					},
					new WaitEvent { timeToWait = 0.5f },
					new StartCastBar { castName = "Cauterize", duration = 6 },
					new WaitEvent { timeToWait = 5.8f },
					new SpawnMechanicEvent { referenceMechanicName = "Divebomb2", isPositionRelative = true, isRotationRelative = true }
				}
			}
		}
	},
	{
		"Dragon2-Mechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 6.3f },
					new SetEnemyMovement
					{
						movementTime = -0.5f,
						moveToTarget = target3
					},
					new WaitEvent { timeToWait = 0.5f },
					new StartCastBar { castName = "Cauterize", duration = 6 },
					new WaitEvent { timeToWait = 5.8f },
					new SpawnMechanicEvent { referenceMechanicName = "Divebomb2", isPositionRelative = true, isRotationRelative = true }
				}
			}
		}
	},
	{
		"Spawn2ndKnights",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-Knight3", isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-Knight4", isPositionRelative = true, isRotationRelative = true }
				}
			}
		}
	},
	{
		"Divebomb",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(20, 3.33f),
			colorHtml = "#99daff",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Twintania.png", colorHtml = "#99daff", visualDuration = 6, relativePosition = Vector3.up, scale = new Vector3(2, 2, 2), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 4 },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "Twister",
						spawnOnTarget = true,
						targetingScheme = new TargetAllPlayers()
					},
					new WaitEvent {timeToWait = 1.8f },
					new ModifyMechanicEvent { referenceMechanicName = "Visible" },
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
		"Divebomb2",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(16, 6.67f),
			colorHtml = "#64439b",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 300000, damageType = "Damage", name = "Cauterize" },
							new KnockbackEffect { knockbackDistance = 10 },
						}
					}
				}
			}
		}
	},
	{
		"DivebombTarget",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Chakram.png", colorHtml = "#699500", visualDuration = 6, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), isBillboard = true }
		}
	},
	{
		"SpiralThrust",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(52/3f, 16/3f),
			colorHtml = "#ffae00",
			visible = false,
			isTargeted = true,
			followSpeed = 0,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 5.8f },
					new ModifyMechanicEvent { referenceMechanicName = "Visible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Spiral Thrust (Pretend this is proximity)" },
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
			collisionShapeParams = new Vector4(10, 360, 2f),
			colorHtml = "#5e00c8",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Dynamo" },
					}
				}
			}
		}
	},
	{
		"Protean",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(10, 30),
			colorHtml = "#ffae00",
			isTargeted = true,
			followSpeed = 0,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 50000, damageType = "Damage", name = "Ascalon's Mercy Revealed" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" }
						}
					}
				}
			}
		}
	},
	{
		"Spawn-Thordan",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "King Thordan",
				textureFilePath = "Mechanics/Resources/Thordan.png",
				colorHtml = "#30015d",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				hitboxSize = 3f,
				visualPosition = new Vector3(0, 1.5f, 0),
				visualScale = Vector3.one * 3,
				position = new Vector2(0, 0),
				rotation = 180,
				referenceMechanicName = "ThordanMechanics",
				isTargetable = false,
			},
		}
	},
	{
		"Spawn-Twintania",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Vedrfolnir",
				textureFilePath = "Mechanics/Resources/Twintania.png",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				hitboxSize = 2,
				isPositionRelative = true,
				isRotationRelative = true,
				isVisible = false,
				position = new Vector3(0, -6.67f, 0),
				referenceMechanicName = "TwintaniaMechanics",
				isTargetable = false,
			},
		}
	},
	{
		"Spawn-Knight1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Ser Knight1",
				textureFilePath = "Mechanics/Resources/Knight.png",
				colorHtml = "#8c38ff",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 0.5f, 0),
				visualScale = new Vector3(-1, 1, 1),
				isPositionRelative = true,
				isRotationRelative = true,
				position = new Vector3(0.5f, 0.866f, 0) * 6.67f,
				referenceMechanicName = "Knight1-Mechanics",
				isTargetable = false,
			},
		}
	},
	{
		"Spawn-Knight2",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Ser Knight2",
				textureFilePath = "Mechanics/Resources/Knight.png",
				colorHtml = "#8c38ff",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 0.5f, 0),
				visualScale = new Vector3(-1, 1, 1),
				isPositionRelative = true,
				isRotationRelative = true,
				position = new Vector3(-0.5f, 0.866f, 0) * 6.67f,
				referenceMechanicName = "Knight2-Mechanics",
				isTargetable = false,
			},
		}
	},
	{
		"Spawn-Knight3",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Ser Charibert",
				textureFilePath = "Mechanics/Resources/Charibert.png",
				colorHtml = "#c42e00",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 0.5f, 0),
				visualScale = new Vector3(-1, 1, 1),
				isPositionRelative = true,
				isRotationRelative = true,
				position = new Vector3(0, 0.5f, 0) * 6.67f,
				referenceMechanicName = "Knight3-Mechanics",
				isTargetable = false,
			},
		}
	},
	{
		"Spawn-Knight4",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Ser Grinnaux",
				textureFilePath = "Mechanics/Resources/Grinnaux.png",
				colorHtml = "#5e00c8",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 0.5f, 0),
				visualScale = new Vector3(-1, 1, 1),
				isPositionRelative = true,
				isRotationRelative = true,
				position = new Vector3(0, -0.5f, 0) * 6.67f,
				referenceMechanicName = "Knight4-Mechanics",
				isTargetable = false,
			},
		}
	},
	{
		"Spawn-Dragon1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Darkscale",
				textureFilePath = "Mechanics/Resources/Twintania.png",
				colorHtml = "#64439b",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 0.5f, 0),
				visualScale = new Vector3(-1, 1, 1),
				isPositionRelative = true,
				isRotationRelative = true,
				position = new Vector3(-1, 0, 0) * 6.67f,
				referenceMechanicName = "Dragon1-Mechanics",
				isTargetable = false,
			},
		}
	},
	{
		"Spawn-Dragon2",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Vidofnir",
				textureFilePath = "Mechanics/Resources/Twintania.png",
				colorHtml = "#99daff",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 0.5f, 0),
				visualScale = new Vector3(-1, 1, 1),
				isPositionRelative = true,
				isRotationRelative = true,
				position = new Vector3(1, 0, 0) * 6.67f,
				referenceMechanicName = "Dragon2-Mechanics",
				isTargetable = false,
			},
		}
	},
	{
		"Altar Flare",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2.67f, 360),
			colorHtml = "#c42e00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 4 },
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Altar Flare" } },
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
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 10000, damageType = "Magic", name = "Liquid Hell" } },
					new WaitEvent { timeToWait = 12 },
				}
			},
			persistentTickInterval = 0.3f,
			persistentActivationDelay = 3,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Burns" } },
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
		"Visible",
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
					new ModifyMechanicEvent { referenceMechanicName = "Visible" },
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
		"Lightning-AOE",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(5/3f, 360),
			colorHtml = "#c30bff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerIsMechanicTarget(),
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 999999, damageType = "Lightning", name = "Chain Lightning" }
						}
					},
				}
			}
		}
	},
	{
		"Defamation",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(8, 360),
			colorHtml = "#0b89ff",
			isTargeted = true,
			followSpeed = 10000,
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Chakram.png", colorHtml = "#0b89ff", visualDuration = 6, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), isBillboard = true },
					new WaitEvent { timeToWait = 5.8f },
					new ModifyMechanicEvent { referenceMechanicName = "Visible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 50000, damageType = "Damage", name = "Skyward Leap" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" }
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
	}
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"MagicVuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/MagicVuln.png",
			statusName = "Magic Vulnerability Up",
			statusDescription = "Magic damage taken is increased.",
			damageType = "Magic",
			damageMultiplier = 10,
			duration = 13,
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
			duration = 4,
		}
	},
	{
		"Lightning",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/LightningPlus.png",
			statusName = "Thunderstruck",
			statusDescription = "Body is accumulating charge. Will inflict lightning damage to those nearby when this effect expires.",
			duration = 16,
			referenceMechanicName = "Lightning-AOE"
		}
	},
	{
		"LiquidHellTarget",
		new StatusEffectData
		{
			statusIconPath = null,
			statusName = "LiquidHellTarget",
			statusDescription = null,
			duration = 99
		}
	},
};

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>();
mechanicData.mechanicPools["Adds1Pool"] = new List<MechanicEvent>();
mechanicData.mechanicPools["Adds2Pool"] = new List<MechanicEvent>();
mechanicData.mechanicPools["LiquidHellPool"] = new List<MechanicEvent>();

foreach (var i in new List<float> {0, 90, 180, 270})
{
	mechanicData.mechanicPools["Adds1Pool"].Add(new SpawnMechanicEvent
	{
		referenceMechanicName = "SpawnAdds1",
		isRotationRelative = true,
		isPositionRelative = true,
		rotation = i
	});
}

foreach (var i in new List<float> { 0, 180 })
{
	mechanicData.mechanicPools["Adds2Pool"].Add(new SpawnMechanicEvent
	{
		referenceMechanicName = "Spawn2ndKnights",
		isRotationRelative = true,
		isPositionRelative = true,
		rotation = i
	});
}

for (int i = 3; i <= 7; i++)
{
	mechanicData.mechanicPools["LiquidHellPool"].Add(new SpawnTargetedEvents
	{
		referenceMechanicName = "LiquidHellSequence",
		targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{3} }
	});
}

mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"SpiralThrustTether",
		new TetherProperties
		{
			colorHtml = "#ffae00",
			tetherDuration = 6,
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
		scale = new Vector3(15.2f, 15.2f, 1),
	},
	new SpawnMechanicEvent{	referenceMechanicName = "Spawn-Thordan" }
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
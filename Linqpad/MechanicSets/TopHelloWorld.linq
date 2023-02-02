<Query Kind="Statements">
  <Reference>E:\Downloads\xiv\xivsim\XivMechanicSimNetworked_Data\Managed\Assembly-CSharp.dll</Reference>
  <Reference>E:\Downloads\xiv\xivsim\XivMechanicSimNetworked_Data\Managed\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "TopHelloWorld";
var baseOutputPath = @"E:\Downloads\xiv\xivsim\";
var buildOutputPath = @"E:\Downloads\xiv\xivsim\Build";

var mechanicData = new MechanicData();

float ScaleToSim(float gameScale)
{
	return gameScale / 3f;
}

TargetSpecificPlayerIds n1 = new TargetSpecificPlayerIds { targetIds = new List<int>{0, 1} };
TargetSpecificPlayerIds n2 = new TargetSpecificPlayerIds { targetIds = new List<int>{2, 3} };
TargetSpecificPlayerIds n3 = new TargetSpecificPlayerIds { targetIds = new List<int>{4, 5} };
TargetSpecificPlayerIds n4 = new TargetSpecificPlayerIds { targetIds = new List<int>{6, 7} };

float towerDistance = 4.733f;

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
					new ReshufflePlayerIds(),
					new WaitEvent { timeToWait = 1f },
					new StartCastBar { castName = "Hello World", duration = 2 },
					new WaitEvent { timeToWait = 2f },
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide" },
					new SpawnMechanicEvent { referenceMechanicName = "ApplyDebuffs" },
					new WaitEvent { timeToWait = 14f },
					new ExecuteRandomEvents { mechanicPoolName = "TowerPool"},
					new StartCastBar { castName = "Latent Defect", duration = 10 },
					new WaitEvent { timeToWait = 21f },
					new ExecuteRandomEvents { mechanicPoolName = "TowerPool"},
					new StartCastBar { castName = "Latent Defect", duration = 10 },
					new WaitEvent { timeToWait = 21f },
					new ExecuteRandomEvents { mechanicPoolName = "TowerPool"},
					new StartCastBar { castName = "Latent Defect", duration = 10 },
					new WaitEvent { timeToWait = 21f },
					new ExecuteRandomEvents { mechanicPoolName = "TowerPool"},
					new StartCastBar { castName = "Latent Defect", duration = 10 },
					new WaitEvent { timeToWait = 21f },
					new StartCastBar { castName = "Critical Error", duration = 7 },
					new WaitEvent { timeToWait = 7f },
					new SpawnMechanicEvent { referenceMechanicName = "CriticalError"},
					new WaitEvent { timeToWait = float.PositiveInfinity },
				}
			}
		}
	},
	{
		"ApplyDebuffs",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ExecuteRandomEvents { mechanicPoolName = "RotPool"},
					new SpawnTargetedEvents { referenceMechanicName = "ApplySmellyStack", targetingScheme = n2 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyLatentDna", targetingScheme = n1 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplySmellyDefamation", targetingScheme = n4 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyLatent", targetingScheme = new TargetAllPlayers {} },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyFar1", targetingScheme = n3 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyFar2", targetingScheme = n4 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyFar3", targetingScheme = n1 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyFar4", targetingScheme = n2 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyNear1", targetingScheme = n1 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyNear2", targetingScheme = n2 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyNear3", targetingScheme = n3 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyNear4", targetingScheme = n4 },
					new SpawnMechanicEvent { referenceMechanicName = "TetherManager" },
					
				}
			}
		}
	},
	{
		"RedIsDefamation",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents { referenceMechanicName = "ApplySmellyPinkRot", targetingScheme = n4 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplySmellyBlueRot", targetingScheme = n2 },
					
				}
			}
		}
	},
	{
		"BlueIsDefamation",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents { referenceMechanicName = "ApplySmellyPinkRot", targetingScheme = n2 },
					new SpawnTargetedEvents { referenceMechanicName = "ApplySmellyBlueRot", targetingScheme = n4 },
					
				}
			}
		}
	},
	{
		"TetherManager",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2f },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Green-Smelly", targetingScheme = n1, tetherIndices = n1.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Blue-Smelly", targetingScheme = n3, tetherIndices = n3.targetIds },
					new WaitEvent { timeToWait = 21f },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Green", targetingScheme = n1, tetherIndices = n1.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Blue", targetingScheme = n3, tetherIndices = n3.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Green-Smelly", targetingScheme = n2, tetherIndices = n2.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Blue-Smelly", targetingScheme = n4, tetherIndices = n4.targetIds },
					new WaitEvent { timeToWait = 21f },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Green", targetingScheme = n2, tetherIndices = n2.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Blue", targetingScheme = n4, tetherIndices = n4.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Green-Smelly", targetingScheme = n3, tetherIndices = n3.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Blue-Smelly", targetingScheme = n1, tetherIndices = n1.targetIds },
					new WaitEvent { timeToWait = 21f },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Green", targetingScheme = n3, tetherIndices = n3.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Blue", targetingScheme = n1, tetherIndices = n1.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Green-Smelly", targetingScheme = n4, tetherIndices = n4.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Blue-Smelly", targetingScheme = n2, tetherIndices = n2.targetIds },
					new WaitEvent { timeToWait = 21f },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Green", targetingScheme = n4, tetherIndices = n4.targetIds },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Blue", targetingScheme = n2, tetherIndices = n2.targetIds },
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
					new SpawnMechanicEvent { referenceMechanicName = "RedTower", position = new Vector2(towerDistance, 0), isPositionRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "RedTower", position = new Vector2(0, towerDistance), isPositionRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "BlueTower", position = new Vector2(-towerDistance, 0), isPositionRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "BlueTower", position = new Vector2(0, -towerDistance), isPositionRelative = true },
				}
			}
		}
	},
	{
		"RedTower",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2.1f, 360),
			colorHtml = "#ff1111",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 9.7f },
					new ModifyMechanicEvent { referenceMechanicName = "SetInvisible" },
					new WaitEvent { timeToWait = 0.5f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new CheckNumberOfPlayers
					{
						expressionFormat = $"{{0}} > 0",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "PinkRotFail" }
					},
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Cascading Latent Defect" },
							new ApplyStatusEffect { referenceStatusName = "PinkDna" }
						}
					}
				}
			},
		}
	},
	{
		"BlueTower",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2.1f, 360),
			colorHtml = "#1111ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 9.7f },
					new ModifyMechanicEvent { referenceMechanicName = "SetInvisible" },
					new WaitEvent { timeToWait = 0.5f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new CheckNumberOfPlayers
					{
						expressionFormat = $"{{0}} > 0",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "BlueRotFail" }
					},
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Latent Performance Defect" },
							new ApplyStatusEffect { referenceStatusName = "BlueRavioli" }
						}
					}
				}
			},
		}
	},
	{
		"DefamationExplosion",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(ScaleToSim(20), 360),
			colorHtml = "#000000aa",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerIsMechanicTarget(),
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 80000, damageType = "Magic", name = "Critical Overflow Bug" },
							new ApplyStatusEffect { referenceStatusName = "DefamationDebugger" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 80000, damageType = "Magic", name = "Critical Overflow Bug" },
							new ApplyStatusEffect { referenceStatusName = "TryDefamation" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new RemoveStatusEffect { referenceStatusName = "LatentDna" },
						}
					},
				}
			},
		}
	},
	{
		"StackExplosion",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(ScaleToSim(5), 360),
			colorHtml = "#000000aa",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers 
					{ 
						effect = new DamageEffect { damageAmount = 160000, damageType = "Magic", name = "Critical Synchronization Bug" , maxStackAmount = 2}
					},
					new ApplyEffectToPlayers {
						condition = new CheckPlayerIsMechanicTarget(),
						effects = new List<MechanicEffect>
						{
							new ApplyStatusEffect { referenceStatusName = "StackDebugger" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new RemoveStatusEffect { referenceStatusName = "LatentDna" },
							new RemoveStatusEffect { referenceStatusName = "LatentStack" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new ApplyStatusEffect { referenceStatusName = "TryStack" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new RemoveStatusEffect { referenceStatusName = "LatentDna" },
							new RemoveStatusEffect { referenceStatusName = "LatentStack" },
						}
					},
				}
			},
		}
	},
	{
		"PinkRotExplosion",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(ScaleToSim(5), 360),
			colorHtml = "#880000aa",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
					condition = new CheckPlayerIsMechanicTarget(),
					effects = new List<MechanicEffect> 
					{
						new ApplyStatusEffect { referenceStatusName = "PinkRotDebugger" },
						new RemoveStatusEffect { referenceStatusName = "PinkDna" },
					},
					failedConditionEffects = new List<MechanicEffect>
					{
						new DamageEffect { damageAmount = 9999999, damageType = "Damage", name = "Critical Underflow Bug" },
					}
				},
				}
			},
		}
	},
	{
		"BlueRotExplosion",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(ScaleToSim(5), 360),
			colorHtml = "#000088aa",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
					condition = new CheckPlayerIsMechanicTarget(),
					effects = new List<MechanicEffect> 
					{
						new ApplyStatusEffect { referenceStatusName = "BlueRotDebugger" },
						new RemoveStatusEffect { referenceStatusName = "BlueRavioli" },
					},
					failedConditionEffects = new List<MechanicEffect>
					{
						new DamageEffect { damageAmount = 9999999, damageType = "Damage", name = "Critical Performance Bug" },
					}
				},
				}
			},
		}
	},
	{
		"PinkRotChaser",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.5f, 360),
			isTargeted = true,
			followSpeed = 10000,
			persistentTickInterval = 0.1f,
			persistentActivationDelay = 0,
			visible = false,
			mechanic = new WaitEvent { timeToWait = 26.9f },
			persistentMechanic = new SpawnTargetedEvents { referenceMechanicName = "ApplyPinkRot", targetingScheme = new TargetPlayersInsideAoe {} }
		}
	},
	{
		"BlueRotChaser",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.5f, 360),
			isTargeted = true,
			followSpeed = 10000,
			persistentTickInterval = 0.1f,
			persistentActivationDelay = 0,
			visible = false,
			mechanic = new WaitEvent { timeToWait = 26.9f },
			persistentMechanic = new SpawnTargetedEvents { referenceMechanicName = "ApplyBlueRot", targetingScheme = new TargetPlayersInsideAoe {} }
		}
	},
	{
		"SpawnOmega",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Omega",
				textureFilePath = "Mechanics/Resources/FinalOmega.png",
				colorHtml = "#30015d",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				hitboxSize = 14f,
				visualPosition = new Vector3(0, 1.5f, 0),
				visualScale = Vector3.one * 3,
				position = new Vector2(0, 0),
				rotation = 180,
				referenceMechanicName = "OmegaMechanics",
				isTargetable = true,
			},
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
		"Patch",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(50, 360),
			colorHtml = "#00000088",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 5000, damageType = "Magic", name = "Patch" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new ApplyStatusEffect { referenceStatusName = "DoomStack" },
							new RemoveStatusEffect { referenceStatusName = "NearTether" },
							new RemoveStatusEffect { referenceStatusName = "FarTether" },
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
				effect = new DamageEffect { damageAmount = 80000, damageType = "Magic", name = "Hello World" }
			}
		}
	},
	{
		"BlueRotFail",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			colorHtml = "#1111ff",
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 9999999, damageType = "Damage", name = "Blue Explosion" }
			}
		}
	},
	{
		"PinkRotFail",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			colorHtml = "#ff3333",
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 9999999, damageType = "Damage", name = "Red Explosion" }
			}
		}
	},
	{
		"CriticalError",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers 
					{ 
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 80000, damageType = "Magic", name = "Critical Error" },
							new ApplyStatusEffect { referenceStatusName = "TryDefamation" },
						}
					}
				}
			}
		}
	},
	{
		"ApplyNear1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyNear", overrideDuration = 23f }
			}
		}
	},
	{
		"ApplyNear2",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyNear", overrideDuration = 44f }
			}
		}
	},
	{
		"ApplyNear3",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyNear", overrideDuration = 65f }
			}
		}
	},
	{
		"ApplyNear4",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyNear", overrideDuration = 86f }
			}
		}
	},
	{
		"ApplyFar1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyFar", overrideDuration = 23f }
			}
		}
	},
	{
		"ApplyFar2",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyFar", overrideDuration = 44f }
			}
		}
	},
	{
		"ApplyFar3",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyFar", overrideDuration = 65f }
			}
		}
	},
	{
		"ApplyFar4",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyFar", overrideDuration = 86f }
			}
		}
	},
	{
		"ApplyNear",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "NearTether" }
			}
		}
	},
	{
		"ApplyFar",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "FarTether" }
			}
		}
	},
	{
		"ApplyLatent",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "LatentStack" }
			}
		}
	},
	{
		"ApplyLatentDna",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "LatentDna" }
			}
		}
	},
	{
		"ApplyPinkDna",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "PinkDna" }
			}
		}
	},
	{
		"ApplyBlueRavioli",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "BlueRavioli" }
			}
		}
	},
	{
		"ApplySmellyDefamation",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyDefamation" }
			}
		}
	},
	{
		"ApplySmellyStack",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyStack" }
			}
		}
	},
	{
		"ApplySmellyPinkRot",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyPinkRot" }
			}
		}
	},
	{
		"ApplySmellyBlueRot",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SmellyBlueRot" }
			}
		}
	},
	{
		"ApplyDefamation",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							statusName = "Critical Overflow Bug",
						},
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 9999999, damageType = "Damage", name = "Double Defamation" },
						},
						failedConditionEffects = new List<MechanicEffect> {}
					},
					new ApplyEffectToPlayers {
						condition = new CheckMultipleConditions
						{
							requireAll = true,
							conditions = new List<Condition>
							{
								new CheckPlayerStatus
								{
									invertStatus = true,
									statusName = "Critical Overflow Bug",
								},
								new CheckPlayerStatus
								{
									invertStatus = true,
									statusName = "Overflow Debugger"
								},
							}
						},
						effects = new List<MechanicEffect>
						{
							new ApplyStatusEffect { referenceStatusName = "Defamation" },
						},
						failedConditionEffects = new List<MechanicEffect> {}
					},
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							statusName = "Overflow Debugger",
						},
						effects = new List<MechanicEffect>
						{
							new RemoveStatusEffect { referenceStatusName = "DefamationDebugger" },
						},
						failedConditionEffects = new List<MechanicEffect> {}
					},
				}
			}
		}
	},
	{
		"ApplyStack",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							statusName = "Critical Synchronization Bug",
						},
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 9999999, damageType = "Damage", name = "Double Stack" },
						},
						failedConditionEffects = new List<MechanicEffect> {}
					},
					new ApplyEffectToPlayers {
						condition = new CheckMultipleConditions
						{
							requireAll = true,
							conditions = new List<Condition>
							{
								new CheckPlayerStatus
								{
									invertStatus = true,
									statusName = "Critical Synchronization Bug",
								},
								new CheckPlayerStatus
								{
									invertStatus = true,
									statusName = "Synchronization Debugger"
								},
							}
						},
						effects = new List<MechanicEffect>
						{
							new ApplyStatusEffect { referenceStatusName = "Stack" },
						},
						failedConditionEffects = new List<MechanicEffect> {}
					},
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							statusName = "Synchronization Debugger",
						},
						effects = new List<MechanicEffect>
						{
							new RemoveStatusEffect { referenceStatusName = "StackDebugger" },
						},
						failedConditionEffects = new List<MechanicEffect> {}
					},
				}
			}
		}
	},
	{
		"ApplyPinkRot",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				condition = new CheckMultipleConditions
				{
					requireAll = true,
					conditions = new List<Condition>
					{
						new CheckPlayerStatus
						{
							invertStatus = true,
							statusName = "Critical Underflow Bug",
						},
						new CheckPlayerStatus
						{
							invertStatus = true,
							statusName = "Underflow Debugger",
						},
					}
				},
				effects = new List<MechanicEffect>
				{
					new ApplyStatusEffect { referenceStatusName = "PinkRot" },
					new ApplyStatusEffect { referenceStatusName = "PinkRotHelper" },
				},
				failedConditionEffects = new List<MechanicEffect> {}
			},
		}
	},
	{
		"ApplyBlueRot",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				condition = new CheckMultipleConditions
				{
					requireAll = true,
					conditions = new List<Condition>
					{
						new CheckPlayerStatus
						{
							invertStatus = true,
							statusName = "Critical Performance Bug",
						},
						new CheckPlayerStatus
						{
							invertStatus = true,
							statusName = "Performance Debugger",
						},
					}
				},
				effects = new List<MechanicEffect>
				{
					new ApplyStatusEffect { referenceStatusName = "BlueRot" },
					new ApplyStatusEffect { referenceStatusName = "BlueRotHelper" },
				},
				failedConditionEffects = new List<MechanicEffect> {}
			},
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
		"Chain-Blue-Smelly",
		new TetherProperties
		{
			colorHtml = "#0000ff55",
			tetherDuration = 21,
		}
	},
	{
		"Chain-Blue",
		new TetherProperties
		{
			colorHtml = "#0000ff",
			tetherDuration = 10,
			breakOnTetherExpired = true,
			persistentActivationDelay = 0.1f,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = -1,
				maxDistance = 2.66f,
				successEvent = new ModifyTetherProperties { referenceTetherName = "Chain-Blue-Active" },
				failEvent = new EndTether { shouldTriggerBreakEvent = true }
			},
			breakMechanic = new SpawnMechanicOnTetheredPlayers {
				spawnOnBoth = true,
				referenceMechanicName = "Patch"
			},
		}
	},
	{
		"Chain-Blue-Active",
		new TetherProperties
		{
			colorHtml = "#0000ff"
		}
	},
	{
		"Chain-Green-Smelly",
		new TetherProperties
		{
			colorHtml = "#00ff0055",
			tetherDuration = 21,
		}
	},
	{
		"Chain-Green",
		new TetherProperties
		{
			colorHtml = "#00ff00",
			tetherDuration = 10,
			breakOnTetherExpired = true,
			persistentActivationDelay = 0.1f,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = 2.66f,
				maxDistance = 999,
				successEvent = new ModifyTetherProperties { referenceTetherName = "Chain-Green-Active" },
				failEvent = new EndTether { shouldTriggerBreakEvent = true }
			},
			breakMechanic = new SpawnMechanicOnTetheredPlayers {
				spawnOnBoth = true,
				referenceMechanicName = "Patch"
			},
		}
	},
	{
		"Chain-Green-Active",
		new TetherProperties
		{
			colorHtml = "#00ff00"
		}
	},
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
			maxStacks = 16,
			duration = 1,
		}
	},
	{
		"DoomStack",
		new SpawnMechanicOnReachStacks
		{
			statusIconPath = "Mechanics/Resources/DoomStack.png",
			statusName = "Thrice-come Ruin",
			statusDescription = "Too many stacks will result in Doom.",
			referenceMechanicName = "ApplyDoom",
			requiredStacks = 3,
			maxStacks = 3,
			duration = 1,
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
	{
		"SmellyNear",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/NearTether1.png",
			statusName = "Local Code Smell",
			statusDescription = "Smelling an incoming green tether.",
			duration = 22,
			canOverwriteStatus = false,
			referenceMechanicName = "ApplyNear",
		}
	},
	{
		"SmellyFar",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/FarTether1.png",
			statusName = "Remote Code Smell",
			statusDescription = "Smelling an incoming blue tether.",
			duration = 22,
			canOverwriteStatus = false,
			referenceMechanicName = "ApplyFar",
		}
	},
	{
		"NearTether",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/NearTether2.png",
			statusName = "Local Regression",
			statusDescription = "Green tether will pop if too close to partner.",
			canOverwriteStatus = false,
			duration = 10,
		}
	},
	{
		"FarTether",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/FarTether2.png",
			statusName = "Remote Regression",
			statusDescription = "Blue tether will pop if too far from partner.",
			canOverwriteStatus = false,
			duration = 10,
		}
	},
	{
		"LatentStack",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/SharedSentenceL.png",
			statusName = "Latent Synchronization Bug",
			statusDescription = "Sentenced to share a stack.",
			duration = 72,
			referenceMechanicName = "Doom",
		}
	},
	{
		"LatentDna",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/BlueDna.png",
			statusName = "Latent Defect",
			statusDescription = "Sentenced to get hit by a mechanic.",
			duration = 26,
			referenceMechanicName = "Doom",
		}
	},
	{
		"Defamation",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/Defamation.png",
			statusName = "Critical Overflow Bug",
			statusDescription = "Exploding in a large radius at the end of this effect.",
			duration = 21,
			referenceMechanicName = "DefamationExplosion",
			shouldKeepOnDeath = true,
		}
	},
	{
		"Stack",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/SharedSentence.png",
			statusName = "Critical Synchronization Bug",
			statusDescription = "Exploding with shared damage at the end of this effect.",
			duration = 21,
			referenceMechanicName = "StackExplosion",
			shouldKeepOnDeath = true,
		}
	},
	{
		"PinkRot",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/PinkRot.png",
			statusName = "Critical Underflow Bug",
			statusDescription = "Affected by an underflow bug and spreading it to touched allies.",
			duration = 27,
			referenceMechanicName = "PinkRotExplosion",
			shouldKeepOnDeath = true,
		}
	},
	{
		"BlueRot",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/BlueRot.png",
			statusName = "Critical Performance Bug",
			statusDescription = "Affected by a performance bug and spreading it to touched allies.",
			duration = 27,
			referenceMechanicName = "BlueRotExplosion",
			shouldKeepOnDeath = true,
		}
	},
	{
		"PinkRotHelper",
		new SpawnMechanicOnExpire
		{
			statusName = "Pink Rot Spread",
			statusDescription = "Helper status to spread rot.",
			duration = 0.1f,
			referenceMechanicName = "PinkRotChaser"
		}
	},
	{
		"BlueRotHelper",
		new SpawnMechanicOnExpire
		{
			statusName = "Blue Rot Spread",
			statusDescription = "Helper status to spread rot.",
			duration = 0.1f,
			referenceMechanicName = "BlueRotChaser"
		}
	},
	{
		"SmellyDefamation",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/DefamationS.png",
			statusName = "Overflow Code Smell",
			statusDescription = "Smelling an incoming defamation.",
			duration = 3,
			referenceMechanicName = "ApplyDefamation",
			shouldKeepOnDeath = true,
		}
	},
	{
		"SmellyStack",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/SharedSentenceS.png",
			statusName = "Synchronization Code Smell",
			statusDescription = "Smelling an incoming stack.",
			duration = 3,
			referenceMechanicName = "ApplyStack",
			shouldKeepOnDeath = true,
		}
	},
	{
		"SmellyPinkRot",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/PinkRotS.png",
			statusName = "Underflow Code Smell",
			statusDescription = "Smelling pink rot incoming.",
			duration = 3,
			referenceMechanicName = "PinkRotChaser",
			shouldKeepOnDeath = true,
		}
	},
	{
		"SmellyBlueRot",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/BlueRotS.png",
			statusName = "Performance Code Smell",
			statusDescription = "Smelling blue rot incoming.",
			duration = 3,
			referenceMechanicName = "BlueRotChaser",
			shouldKeepOnDeath = true,
		}
	},
	{
		"DefamationDebugger",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/DefamationD.png",
			statusName = "Overflow Debugger",
			statusDescription = "Immune to the next overflow bug.",
			duration = 99,
		}
	},
	{
		"StackDebugger",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/SharedSentenceD.png",
			statusName = "Synchronization Debugger",
			statusDescription = "Immune to the next synchronization bug.",
			duration = 99,
		}
	},
	{
		"PinkRotDebugger",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/PinkRotD.png",
			statusName = "Underflow Debugger",
			statusDescription = "Immune to underflow bugs.",
			duration = 99,
		}
	},
	{
		"BlueRotDebugger",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/BlueRotD.png",
			statusName = "Performance Debugger",
			statusDescription = "Immune to performance bugs.",
			duration = 99,
		}
	},
	{
		"PinkDna",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/PinkDna.png",
			statusName = "Cascading Latent Defect",
			statusDescription = "Performing a massive explosion upon effect expiry. Effect can be cleansed via a certain action.",
			duration = 10,
			referenceMechanicName = "PinkRotFail",
		}
	},
	{
		"BlueRavioli",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/BlueRavioli.png",
			statusName = "Latent Performance Defect",
			statusDescription = "Performing a massive explosion upon effect expiry. Effect can be cleansed via a certain action.",
			duration = 10,
			referenceMechanicName = "BlueRotFail",
		}
	},
	{
		"TryDefamation",
		new SpawnMechanicOnExpire
		{
			statusName = "Defamation Pending",
			statusDescription = "Performing defamation application logic.",
			duration = 0.01f,
			referenceMechanicName = "ApplyDefamation",
		}
	},
	{
		"TryStack",
		new SpawnMechanicOnExpire
		{
			statusName = "Stack Pending",
			statusDescription = "Performing stack application logic.",
			duration = 0.01f,
			referenceMechanicName = "ApplyStack",
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" },
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaCircleFinalMarkers.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(15.85f, 15.85f, 1),
	},
	new WaitEvent { timeToWait = 1f },
	new SpawnMechanicEvent { referenceMechanicName = "SpawnOmega" },
};
mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"RotPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "RedIsDefamation" },
			new SpawnMechanicEvent {referenceMechanicName = "BlueIsDefamation" },
		}
	},
};
	
var startPool = new List<MechanicEvent>();
mechanicData.mechanicPools["TowerPool"] = startPool;

for (int i = 0; i < 8; i++)
{
	startPool.Add(new SpawnMechanicEvent { referenceMechanicName = "SpawnTowers", rotation = i * 45, position = new Vector2(0, 0), isRotationRelative = true });
}

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
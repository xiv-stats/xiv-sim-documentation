<Query Kind="Statements">
  <Reference>E:\Downloads\xiv\xivsim\XivMechanicSimNetworked_Data\Managed\Assembly-CSharp.dll</Reference>
  <Reference>E:\Downloads\xiv\xivsim\XivMechanicSimNetworked_Data\Managed\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "PartySynergy";
var baseOutputPath = @"E:\Downloads\xiv\xivsim\";
var buildOutputPath = @"E:\Downloads\xiv\xivsim\Build";

var mechanicData = new MechanicData();

float ScaleToSim(float gameScale)
{
	return gameScale / 3f;
}

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"OmegaMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new ReshufflePlayerIds(),
					new WaitEvent { timeToWait = 1f },
					new SpawnMechanicEvent { referenceMechanicName = "ApplyPlaystations" },
					new WaitEvent { timeToWait = 0.5f },
					new ExecuteRandomEvents { mechanicPoolName = "EyePool"},
					new WaitEvent { timeToWait = 0.5f },
					new SpawnMechanicEvent { referenceMechanicName = "VulnManager" },
					new WaitEvent { timeToWait = 1f },
					new ExecuteRandomEvents { mechanicPoolName = "OmegaSpawnPool"},
					new ExecuteRandomEvents { mechanicPoolName = "SecondOmegaPool"},
					new WaitEvent { timeToWait = 26f },
					new SpawnMechanicEvent { referenceMechanicName = "CleanupVuln" },
				}
			}
		}
	},
	{
		"ApplyPlaystations",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents { referenceMechanicName = "ApplyTriangle", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{0, 1} } },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyCircle", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{2, 3} } },
					new SpawnTargetedEvents { referenceMechanicName = "ApplySquare", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{4, 5} } },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyX", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{6, 7} } },
					new ExecuteRandomEvents { mechanicPoolName = "TetherPool"},
				}
			}
		}
	},
	{
		"ApplyTriangle",
		new MechanicProperties 
		{
			visible = false,
			mechanic = new SpawnVisualObject
			{
				textureFilePath = $"Mechanics/Resources/PS-Tri.png",
				colorHtml = "#00ff00",
				visualDuration = 5f,
				scale = Vector3.one * 0.5f,
				relativePosition = Vector3.up,
				isBillboard = true,
				spawnOnPlayer = true,
			},
		}
	},
	{
		"ApplyCircle",
		new MechanicProperties 
		{
			visible = false,
			mechanic = new SpawnVisualObject
			{
				textureFilePath = $"Mechanics/Resources/PS-Circle.png",
				colorHtml = "#ff0000",
				visualDuration = 5f,
				scale = Vector3.one * 0.5f,
				relativePosition = Vector3.up,
				isBillboard = true,
				spawnOnPlayer = true,
			},
		}
	},
	{
		"ApplySquare",
		new MechanicProperties 
		{
			visible = false,
			mechanic = new SpawnVisualObject
			{
				textureFilePath = $"Mechanics/Resources/PS-Square.png",
				colorHtml = "#ff00ff",
				visualDuration = 5f,
				scale = Vector3.one * 0.5f,
				relativePosition = Vector3.up,
				isBillboard = true,
				spawnOnPlayer = true,
			},
		}
	},
	{
		"ApplyX",
		new MechanicProperties 
		{
			visible = false,
			mechanic = new SpawnVisualObject
			{
				textureFilePath = $"Mechanics/Resources/PS-X.png",
				colorHtml = "#0000ff",
				visualDuration = 5f,
				scale = Vector3.one * 0.5f,
				relativePosition = Vector3.up,
				isBillboard = true,
				spawnOnPlayer = true,
			},
		}
	},
	{
		"SpawnFirstOmegas",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "MiddleOmega", isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "FirstGirl", position = new Vector3(-3.4f, 0, 0), isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "FirstGuy", position = new Vector3(3.4f, 0, 0), isPositionRelative = true, isRotationRelative = true }
				}
			}
		}
	},
	{
		"SpawnSecondOmegaInter",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "SideOmega", isPositionRelative = true, isRotationRelative = true },
					new WaitEvent { timeToWait = 5.5f },
					new SpawnMechanicEvent { referenceMechanicName = "CardOmegas", }
				}
			}
		}
	},
	{
		"SpawnSecondOmegaCard",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "SideOmega", isPositionRelative = true, isRotationRelative = true },
					new WaitEvent { timeToWait = 5.5f },
					new SpawnMechanicEvent { referenceMechanicName = "InterOmegas", },
				}
			}
		}
	},
	{
		"MiddleOmega",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#777777",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaM.png", colorHtml = "#111111", visualDuration = 5.5f, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 5.5f },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaM.png", colorHtml = "#777777", visualDuration = 2.5f, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 2.5f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 4f },
					new ModifyMechanicEvent { referenceMechanicName = "SetInvisible" },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaF.png", colorHtml = "#777777", visualDuration = 2, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 2f },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaF.png", colorHtml = "#111111", visualDuration = 7, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 5f },
					new SpawnMechanicEvent { referenceMechanicName = "KnockbackFromCenter", isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"SideOmega",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#777777",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaF.png", colorHtml = "#111111", visualDuration = 5.5f, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 5.5f },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaF.png", colorHtml = "#777777", visualDuration = 2.5f, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 2.5f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 4f },
					new ModifyMechanicEvent { referenceMechanicName = "SetInvisible" },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaM.png", colorHtml = "#777777", visualDuration = 2, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 2f },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaM.png", colorHtml = "#111111", visualDuration = 12, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 7.5f },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"FirstGuy",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteRandomEvents { mechanicPoolName = "FirstGuyPool"},
		}
	},
	{
		"FirstGirl",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteRandomEvents { mechanicPoolName = "FirstGirlPool"},
		}
	},
	{
		"ChariotGuy",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaM.png", colorHtml = "#111111", visualDuration = 8.5f, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true,  },
					new WaitEvent { timeToWait = 3f },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"ChariotGuyLong",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaM.png", colorHtml = "#111111", visualDuration = 20.5f, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true,  },
					new WaitEvent { timeToWait = 16f },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"DynamoGuy",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaM-Shield.png", colorHtml = "#111111", visualDuration = 8.5f, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true,  },
					new WaitEvent { timeToWait = 3f },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"PlusGirl",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaF.png", colorHtml = "#111111", visualDuration = 8.5f, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 3f },
					new SpawnMechanicEvent { referenceMechanicName = "Plus", isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"HotWingGirl",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/OmegaF-Blade.png", colorHtml = "#111111", visualDuration = 8.5f, relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true, isBillboard = true, },
					new WaitEvent { timeToWait = 3f },
					new SpawnMechanicEvent { referenceMechanicName = "HotWing", isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"Dynamo",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(8, 360, ScaleToSim(11)),
			colorHtml = "#ff9600",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.7f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 300000, damageType = "Damage", name = "Beyond Strength" }
					}
				}
			}
		}
	},
	{
		"Chariot",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(ScaleToSim(11), 360),
			colorHtml = "#ff9600",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.7f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 300000, damageType = "Damage", name = "Efficient Bladework" }
					}
				}
			}
		}
	},
	{
		"Plus",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "PlusSnapshot", position = new Vector2(-7.333f, 0), rotation = 90, isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "PlusSnapshot", position = new Vector2(0, -7.333f), rotation = 0, isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"PlusSnapshot",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(25, 3.5f),
			colorHtml = "#ff9600",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.7f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 300000, damageType = "Damage", name = "Optimized Blizzard III" }
					}
				}
			}
		}
	},
	{
		"HotWing",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "HotWingSnapshot", position = new Vector2(-7.333f, 4.9f), rotation = 90, isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "HotWingSnapshot", position = new Vector2(-7.333f, -4.9f), rotation = 90, isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"HotWingSnapshot",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(19, 6.4f),
			colorHtml = "#ff9600",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.7f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Superliminal Steel" },
						}
					}
				}
			}
		}
	},
	{
		"SpawnEye",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(20, 5.25f),
			colorHtml = "#0a4d8b",
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/SkyEye.png", colorHtml = "#000000", visualDuration = 17, relativePosition = Vector3.up, scale = new Vector3(4, 4, 4), eulerAngles = new Vector3(0, 180, 0), isRotationRelative = true },
					new WaitEvent { timeToWait = 13.3f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new SpawnTargetedEvents { referenceMechanicName = "Spread", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 } } },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 500000, damageType = "Damage", name = "Eyeball Laser" },
						}
					},
					new ExecuteRandomEvents { mechanicPoolName = "FirstStackPool"},
					new ExecuteRandomEvents { mechanicPoolName = "SecondStackPool"},
				}
			}
		}
	},
	{
		"Stack",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 360),
			colorHtml = "#eeeeee",
			isTargeted = true,
			followSpeed = 10000,
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1f },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 8, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 0, 0) },
					new WaitEvent { timeToWait = 10f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> 
						{ 
							new DamageEffect { damageAmount = 320000, damageType = "Magic", name = "Spotlight", maxStackAmount = 4 },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						},
					},
				}
			}
		}
	},
	{
		"Spread",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#eeeeee",
			isTargeted = true,
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers 
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 80000, damageType = "Magic", name = "Optimized Fire III" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						}
					}
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
							new DamageEffect { damageAmount = 20000, damageType = "Damage", name = "Discharger" },
							new KnockbackEffect { knockbackDistance = 5 },
						}
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
		"SetInvisible",
		new MechanicProperties
		{
			visible = false
		}
	},
	{
		"TryRemoveVuln",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(25, 360),
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers {
						condition = new CheckMultipleConditions
						{
							requireAll = true,
							conditions = new List<Condition>
							{
								new CheckPlayerStatus
								{
									statusName = "Vulnerability Up",
								},
								new CheckPlayerStatus
								{
									statusName = "ClearVulnPending"
								},
							}
						},
						effects = new List<MechanicEffect>
						{
							new RemoveStatusEffect { referenceStatusName = "Vuln" },
							new RemoveStatusEffect { referenceStatusName = "VulnPending" },
							new RemoveStatusEffect { referenceStatusName = "ClearVulnPending" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new RemoveStatusEffect { referenceStatusName = "VulnPending" },
							new RemoveStatusEffect { referenceStatusName = "ClearVulnPending" },
						}
					},
				}
			}
		}
	},
	{
		"TryAddVuln",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(25, 360),
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{	
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers {
						condition = new CheckMultipleConditions
						{
							requireAll = true,
							conditions = new List<Condition>
							{
								new CheckPlayerStatus
								{
									invertStatus = true,
									statusName = "Vulnerability Up",
								},
								new CheckPlayerStatus
								{
									statusName = "VulnPending"
								},
							}
						},
						effects = new List<MechanicEffect>
						{
							new ApplyStatusEffect { referenceStatusName = "Vuln" },
							new RemoveStatusEffect { referenceStatusName = "VulnPending" },
							new RemoveStatusEffect { referenceStatusName = "ClearVulnPending" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new RemoveStatusEffect { referenceStatusName = "VulnPending" },
							new RemoveStatusEffect { referenceStatusName = "ClearVulnPending" },
						}
					},
				}
			}
		}
	},
	{
		"CleanupVuln",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(25, 360),
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{	
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new RemoveStatusEffect { referenceStatusName = "Vuln" },
							new RemoveStatusEffect { referenceStatusName = "VulnPending" },
							new RemoveStatusEffect { referenceStatusName = "ClearVulnPending" },
						}
					},
				}
			}
		}
	},
	{
		"AssignFarTethers",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTethersBetweenPlayers
					{
						targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2, 3, 4, 5, 6, 7 } },
						tetherIndices = new List<int> {0, 1, 2, 3, 4, 5, 6, 7 },
						referenceTetherName = "FarChain",
					},
					new SpawnTargetedEvents { referenceMechanicName = "ApplyFar", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 } } },
				}
			}
		}
	},
	{
		"AssignMidTethers",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTethersBetweenPlayers
					{
						targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2, 3, 4, 5, 6, 7 } },
						tetherIndices = new List<int> {0, 1, 2, 3, 4, 5, 6, 7 },
						referenceTetherName = "MidChain",
					},
					new SpawnTargetedEvents { referenceMechanicName = "ApplyMid", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 } } },
				}
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
				effect = new ApplyStatusEffect { referenceStatusName = "FarGlitch" }
			}
		}
	},
	{
		"ApplyMid",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "MidGlitch" }
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
		"VulnManager",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(25, 360),
			visible = false,
			mechanic = new WaitEvent { timeToWait = 30 },
			persistentTickInterval = 0.1f,
			persistentMechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "TryAddVuln" },
					new SpawnMechanicEvent { referenceMechanicName = "TryRemoveVuln", },
				}
			}
		}
	},
};

mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"MidChain",
		new TetherProperties
		{
			colorHtml = "#DDDDDD55",
			tetherDuration = 28,
			persistentActivationDelay = 1,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = 6.5f,
				maxDistance = 8.3f,
				successEvent = new ApplyEffectToTetheredPlayers { effect = new ApplyStatusEffect { referenceStatusName = "ClearVulnPending" } },
				failEvent = new ApplyEffectToTetheredPlayers { effect = new ApplyStatusEffect { referenceStatusName = "VulnPending" } },
			},
		}
	},
	{
		"FarChain",
		new TetherProperties
		{
			colorHtml = "#DDDDDD55",
			tetherDuration = 28,
			persistentActivationDelay = 1,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = 12,
				maxDistance = 99,
				successEvent = new ApplyEffectToTetheredPlayers { effect = new ApplyStatusEffect { referenceStatusName = "ClearVulnPending" } },
				failEvent = new ApplyEffectToTetheredPlayers { effect = new ApplyStatusEffect { referenceStatusName = "VulnPending" } },
			},
		}
	},
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"Vuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/VulnStack.png",
			statusName = "Vulnerability Up",
			statusDescription = "Damage taken is increased.",
			damageMultiplier = 5,
			maxStacks = 16,
			duration = 60,
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
			damageMultiplier = 4,
			duration = 2,
		}
	},
	{
		"MidGlitch",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/MidGlitch.png",
			statusName = "Mid Glitch",
			statusDescription = "Damage taken is increased when too far from or too close to partner.",
			duration = 28,
		}
	},
	{
		"FarGlitch",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/FarGlitch.png",
			statusName = "Remote Glitch",
			statusDescription = "Damage taken is increased when too close to partner.",
			duration = 28,
		}
	},
	{
		"VulnPending",
		new StatusEffectData
		{
			statusName = "VulnPending",
			statusDescription = "Vuln needs applying.",
			duration = 28,
		}
	},
	{
		"ClearVulnPending",
		new StatusEffectData
		{
			statusName = "ClearVulnPending",
			statusDescription = "Vuln needs clearing.",
			duration = 28,
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" },
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaCircleMF.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(15.85f, 15.85f, 1),
	},
	new SpawnMechanicEvent { referenceMechanicName = "OmegaMechanics" },
};
mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"TetherPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "AssignFarTethers" },
			new SpawnMechanicEvent {referenceMechanicName = "AssignMidTethers" },
		}
	},
	{
		"OmegaSpawnPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "SpawnFirstOmegas", isPositionRelative = true, isRotationRelative = true, rotation = 22.5f},
			new SpawnMechanicEvent {referenceMechanicName = "SpawnFirstOmegas", isPositionRelative = true, isRotationRelative = true, rotation = 67.5f},
			new SpawnMechanicEvent {referenceMechanicName = "SpawnFirstOmegas", isPositionRelative = true, isRotationRelative = true, rotation = 112.5f},
			new SpawnMechanicEvent {referenceMechanicName = "SpawnFirstOmegas", isPositionRelative = true, isRotationRelative = true, rotation = 157.5f},
			new SpawnMechanicEvent {referenceMechanicName = "SpawnFirstOmegas", isPositionRelative = true, isRotationRelative = true, rotation = 202.5f},
			new SpawnMechanicEvent {referenceMechanicName = "SpawnFirstOmegas", isPositionRelative = true, isRotationRelative = true, rotation = 247.5f},
			new SpawnMechanicEvent {referenceMechanicName = "SpawnFirstOmegas", isPositionRelative = true, isRotationRelative = true, rotation = 292.5f},
			new SpawnMechanicEvent {referenceMechanicName = "SpawnFirstOmegas", isPositionRelative = true, isRotationRelative = true, rotation = 337.5f},
		}
	},
	{
		"FirstGuyPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "ChariotGuy", isPositionRelative = true, isRotationRelative = true },
			new SpawnMechanicEvent {referenceMechanicName = "DynamoGuy", isPositionRelative = true, isRotationRelative = true },
		}
	},
	{
		"FirstGirlPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "HotWingGirl", isPositionRelative = true, isRotationRelative = true },
			new SpawnMechanicEvent {referenceMechanicName = "PlusGirl", isPositionRelative = true, isRotationRelative = true },
		}
	},
	{
		"FirstStackPool",
		new List<MechanicEvent>
		{
			new SpawnTargetedEvents { referenceMechanicName = "Stack", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 0 } } },
			new SpawnTargetedEvents { referenceMechanicName = "Stack", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 2 } } },
			new SpawnTargetedEvents { referenceMechanicName = "Stack", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 4 } } },
			new SpawnTargetedEvents { referenceMechanicName = "Stack", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 6 } } },
		}
	},
	{
		"SecondStackPool",
		new List<MechanicEvent>
		{
			new SpawnTargetedEvents { referenceMechanicName = "Stack", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 1 } } },
			new SpawnTargetedEvents { referenceMechanicName = "Stack", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 3 } } },
			new SpawnTargetedEvents { referenceMechanicName = "Stack", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 5 } } },
			new SpawnTargetedEvents { referenceMechanicName = "Stack", spawnOnTarget = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { 7 } } },
		}
	},
};
	
var eyePool = new List<MechanicEvent>();
mechanicData.mechanicPools["EyePool"] = eyePool;
var secondPool = new List<MechanicEvent>();
mechanicData.mechanicPools["SecondOmegaPool"] = secondPool;
List<float> cardX = new List<float>{};
List<float> cardY = new List<float>{};
List<float> cardA = new List<float>{};
List<float> interX = new List<float>{};
List<float> interY = new List<float>{};
List<float> interA = new List<float>{};
for (int i = 0; i < 8; i++)
{
    float a = 2 * Mathf.PI / 8 * i;
    float x = 8 * Mathf.Cos(3 * Mathf.PI / 2 - a);
    float y = 8 * Mathf.Sin(3 * Mathf.PI / 2 - a);
	eyePool.Add(new SpawnMechanicEvent { referenceMechanicName = "SpawnEye", rotation = a * Mathf.Rad2Deg, position = new Vector2(x, y), isPositionRelative = true, isRotationRelative = true });
	float newX = x / 1.8f;
	float newY = y / 1.8f;
	if (i % 2 == 0)
	{
		
		secondPool.Add(new SpawnMechanicEvent { referenceMechanicName = "SpawnSecondOmegaCard", rotation = a * Mathf.Rad2Deg, position = new Vector2(newX, newY), isPositionRelative = true, isRotationRelative = true });
		cardX.Add(newX);
		cardY.Add(newY);
		cardA.Add(a * Mathf.Rad2Deg);
	}
	else
	{
		secondPool.Add(new SpawnMechanicEvent { referenceMechanicName = "SpawnSecondOmegaInter", rotation = a * Mathf.Rad2Deg, position = new Vector2(newX, newY), isPositionRelative = true, isRotationRelative = true });
		interX.Add(newX);
		interY.Add(newY);
		interA.Add(a * Mathf.Rad2Deg);
	}
}

mechanicData.referenceMechanicProperties["CardOmegas"] = new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "ChariotGuyLong", position = new Vector2(cardX[0], cardY[0]), rotation = cardA[0] },
					new SpawnMechanicEvent { referenceMechanicName = "ChariotGuyLong", position = new Vector2(cardX[1], cardY[1]), rotation = cardA[1] },
					new SpawnMechanicEvent { referenceMechanicName = "ChariotGuyLong", position = new Vector2(cardX[2], cardY[2]), rotation = cardA[2] },
					new SpawnMechanicEvent { referenceMechanicName = "ChariotGuyLong", position = new Vector2(cardX[3], cardY[3]), rotation = cardA[3] },
				}
			}
		};
		
mechanicData.referenceMechanicProperties["InterOmegas"] = new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "ChariotGuyLong", position = new Vector2(interX[0], interY[0]), rotation = interA[0] },
					new SpawnMechanicEvent { referenceMechanicName = "ChariotGuyLong", position = new Vector2(interX[1], interY[1]), rotation = interA[1] },
					new SpawnMechanicEvent { referenceMechanicName = "ChariotGuyLong", position = new Vector2(interX[2], interY[2]), rotation = interA[2] },
					new SpawnMechanicEvent { referenceMechanicName = "ChariotGuyLong", position = new Vector2(interX[3], interY[3]), rotation = interA[3] },
				}
			}
		};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
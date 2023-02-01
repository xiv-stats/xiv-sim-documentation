<Query Kind="Statements">
  <Reference>D:\src\Unity\xiv-sim\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "RunSigmaDemo_Incomplete";
var baseOutputPath = @"D:\src\Unity\xiv-sim";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

var groupA = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 } };
var groupB = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3, 4, 5 } };
var targetFarthest = new TargetSpecificProximityPlayers { targetIds = new List<int> { 0 }, targetNthFarthest = true };
var tetherIdx = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
var player01 = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1 } };
var player23 = new TargetSpecificPlayerIds { targetIds = new List<int> { 2, 3 } };
var player45 = new TargetSpecificPlayerIds { targetIds = new List<int> { 4, 5 } };
var player67 = new TargetSpecificPlayerIds { targetIds = new List<int> { 6, 7 } };
var psVisualDuration = 5;

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
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
			mechanicTag = "StartButton",
			persistentMechanic = new CheckNumberOfPlayers
			{
				expressionFormat = "{0} = 0",
				failEvent = new ExecuteMultipleEvents
				{
					events = new List<MechanicEvent>
					{
						new SpawnMechanicEvent{ referenceMechanicName = "Timeline" },
						new ClearMechanicsWithTag { mechanicTag = "StartButton" },
					}
				}
			},
		}
	},
	{
		"Timeline",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTethersBetweenPlayers { referenceTetherName = "PS-Chain-Mid", targetingScheme = groupA, tetherIndices = tetherIdx },
					new SpawnTargetedEvents { referenceMechanicName = "Visual-X", targetingScheme = player01, spawnOnTarget = true, isPositionRelative = true, isRotationRelative = true },
					new SpawnTargetedEvents { referenceMechanicName = "Visual-Circle", targetingScheme = player23, spawnOnTarget = true, isPositionRelative = true, isRotationRelative = true },
					new SpawnTargetedEvents { referenceMechanicName = "Visual-Square", targetingScheme = player45, spawnOnTarget = true, isPositionRelative = true, isRotationRelative = true },
					new SpawnTargetedEvents { referenceMechanicName = "Visual-Triangle", targetingScheme = player67, spawnOnTarget = true, isPositionRelative = true, isRotationRelative = true },

					new WaitEvent { timeToWait = 1 },
					new ExecuteRandomEvents { mechanicPoolName = "Hand-Pool" },
					new WaitEvent { timeToWait = 4 },
					new SpawnMechanicEvent { referenceMechanicName = "SpawnOmega" },
					new WaitEvent { timeToWait = 5 },
					new ReshufflePlayerIds(),
					new SpawnTargetedEvents { referenceMechanicName = "Visual-Cone", targetingScheme = groupB },
					new WaitEvent { timeToWait = 8.8f },
					new SpawnTargetedEvents { referenceMechanicName = "LaserCone", targetingScheme = groupB },
					
					new WaitEvent { timeToWait = 2 },
					new WaitEvent { timeToWait = 6 },
					new SpawnMechanicEvent { referenceMechanicName = "KnockbackFromCenter"},
				}
			}
		}
	},
	{
		"FinalOmegaMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 5 },
					new StartCastBar { castName = "Wave Cannon", duration = 10 },
					new WaitEvent { timeToWait = 12 },
					new SetEnemyVisible { visible = false },
					new WaitEvent { timeToWait = float.PositiveInfinity },
				}
			}
		}
	},
	{
		"OmegaFMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyMovement { movementTime = -1, position = new Vector2(0, 0) },
					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"Visual-X",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnVisualObject {
				textureFilePath = "Mechanics/Resources/PS-X.png",
				colorHtml = "#005aff",
				visualDuration = psVisualDuration,
				isBillboard = true,
				isRotationRelative = true,
				relativePosition = new Vector3(0, 1, 0),
				scale = Vector3.one * 0.5f,
				spawnOnPlayer = true
			}
		}
	},
	{
		"Visual-Circle",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnVisualObject {
				textureFilePath = "Mechanics/Resources/PS-Circle.png",
				colorHtml = "#ff0000",
				visualDuration = psVisualDuration,
				isBillboard = true,
				isRotationRelative = true,
				relativePosition = new Vector3(0, 1, 0),
				scale = Vector3.one * 0.5f,
				spawnOnPlayer = true
			}
		}
	},
	{
		"Visual-Triangle",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnVisualObject {
				textureFilePath = "Mechanics/Resources/PS-Tri.png",
				colorHtml = "#00d742",
				visualDuration = psVisualDuration,
				isBillboard = true,
				isRotationRelative = true,
				relativePosition = new Vector3(0, 1, 0),
				scale = Vector3.one * 0.5f,
				spawnOnPlayer = true
			}
		}
	},
	{
		"Visual-Square",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnVisualObject {
				textureFilePath = "Mechanics/Resources/PS-Square.png",
				colorHtml = "#e400ff",
				visualDuration = psVisualDuration,
				isBillboard = true,
				isRotationRelative = true,
				relativePosition = new Vector3(0, 1, 0),
				scale = Vector3.one * 0.5f,
				spawnOnPlayer = true
			}
		}
	},
	{
		"Visual-Cone",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 8, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 0, 0) },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 8, spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 90, 0) },
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
							new DamageEffect { damageAmount = 0, damageType = "Damage", name = "Heavensfall" },
							new KnockbackEffect { knockbackDistance = 4 },
						}
					}
				}
			}
		}
	},
	{
		"LaserCone",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(50, 60),
			colorHtml = "#0072ff",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 50000, damageType = "Magic", name = "Laser Cone" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln2" }
						}
					}
				}
			}
		}
	},
	{
		"HandLaser",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(30, 2),
			colorHtml = "#ff9000",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 50000, damageType = "Magic", name = "Hand Laser" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln2" }
						}
					},
				}
			}
		}
	},
	{
		"HandMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 17.8f },
					new SpawnTargetedEvents { referenceMechanicName = "HandLaser", targetingScheme = targetFarthest },
			    }
			}
		}
	},
	{
		"SpawnHand",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Hand",
				textureFilePath = "Mechanics/Resources/Hand.png",
				colorHtml = "#000000",
				maxHp = 35000000,
				baseMoveSpeed = 0,
				hitboxSize = 10,
				visualPosition = new Vector3(0, 1, 0),
				visualScale = Vector3.one,
				referenceMechanicName = "HandMechanics",
				position = new Vector2(0, 3.33f),
				isPositionRelative = true,
				isRotationRelative = true,
				isTargetable = false,
			},
		}
	},
	{
		"SpawnOmegaF",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy {
				enemyName = "Omega-M",
				textureFilePath = "Mechanics/Resources/OmegaF.png",
				colorHtml = "#0a4d8b",
				maxHp = 35000000,
				baseMoveSpeed = 0,
				hitboxSize = 10,
				visualPosition = new Vector3(0, 1.5f, 0),
				visualScale = Vector3.one * 2,
				referenceMechanicName = "OmegaFMechanics",
				position = new Vector2(0, 6.66f),
				isPositionRelative = true,
				isRotationRelative = true,
				isTargetable = false,
			},
		}
	},
	{
		"SpawnHands",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "SpawnHand", isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "SpawnHand", isPositionRelative = true, isRotationRelative = true, rotation = 90 },
					new SpawnMechanicEvent { referenceMechanicName = "SpawnOmegaF", isPositionRelative = true, isRotationRelative = true, rotation = 225 },
					new WaitEvent { timeToWait = 19 },
					new ExecuteRandomEvents { mechanicPoolName = "Tower-Pool-Near" },
					new WaitEvent { timeToWait = 1 },
				}
			}
		}
	},
	{
		"SetVisible",
		new MechanicProperties
		{
			visible = true,
		}
	},
	{
		"SetVisibleFalse",
		new MechanicProperties
		{
			visible = false,
		}
	},
	{
		"SpawnOmega",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "FinalOmega",
				textureFilePath = "Mechanics/Resources/UltimaWeapon.png",
				colorHtml = "#0a4d8b",
				maxHp = 35000000,
				baseMoveSpeed = 0,
				hitboxSize = 10,
				visualPosition = new Vector3(0, 2, 0),
				visualScale = Vector3.one * 4,
				referenceMechanicName = "FinalOmegaMechanics",
				position = new Vector2(0, 0),
				isPositionRelative = true,
				isRotationRelative = true,
				isTargetable = false,
			}
		}
	},
	{
		"Spawn-Tower-Pool-Near",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new ExecuteRandomEvents { mechanicPoolName = "Tower-Pool-Near" },
					new WaitEvent { timeToWait = 0.1f }
				}
			}
		}
	},
	{
		"Tower-1",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#c6e2ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = $"Mechanics/Resources/LimitCut-1.png", colorHtml = "#ffe08d", visualDuration = 10, relativePosition = Vector3.up, isBillboard = true },
					new WaitEvent { timeToWait = 10 },
					new CheckNumberOfPlayers
					{
						expressionFormat = $"{{0}} = 1",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "Tower Fail", isPositionRelative = true }
					},
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 60000, damageType = "Damage", name = "Tower" },
						}
					}
				}
			},
			persistentMechanic = new CheckNumberOfPlayers
			{
				expressionFormat = $"{{0}} = 1",
				successEvent = new ModifyMechanicEvent { referenceMechanicName = "Aoe-Green" },
				failEvent = new ModifyMechanicEvent { referenceMechanicName = "Aoe-TowerColor" }
			},
			persistentTickInterval = 0.1f
		}
	},
	{
		"Tower-2",new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#c6e2ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = $"Mechanics/Resources/LimitCut-2.png", colorHtml = "#ffe08d", visualDuration = 10, relativePosition = Vector3.up, isBillboard = true },
					new WaitEvent { timeToWait = 10 },
					new CheckNumberOfPlayers
					{
						expressionFormat = $"{{0}} = 2",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "Tower Fail", isPositionRelative = true }
					},
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 60000, damageType = "Damage", name = "Tower" },
						}
					}
				}
			},
			persistentMechanic = new CheckNumberOfPlayers
			{
				expressionFormat = $"{{0}} = 2",
				successEvent = new ModifyMechanicEvent { referenceMechanicName = "Aoe-Green" },
				failEvent = new ModifyMechanicEvent { referenceMechanicName = "Aoe-TowerColor" }
			},
			persistentTickInterval = 0.1f
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
		"Tower-Offset-1",
		new MechanicProperties {
			visible = false,
			mechanic = new SpawnMechanicEvent { referenceMechanicName = "Tower-1", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 5.66f }
		}
	},
	{
		"Tower-Offset-2",
		new MechanicProperties {
			visible = false,
			mechanic = new SpawnMechanicEvent { referenceMechanicName = "Tower-2", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 5.66f }
		}
	},
	{
		"Aoe-Green",
		new MechanicProperties {
			colorHtml = "#00ff00",
		}
	},
	{
		"Aoe-TowerColor",
		new MechanicProperties {
			colorHtml = "#c6e2ff",
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
		"ApplyVuln",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effects = new List<MechanicEffect> {
					new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
				}
			}
		}
	},
	{
		"RemoveVuln",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effects = new List<MechanicEffect> {
					new RemoveStatusEffect { referenceStatusName = "MagicVuln" },
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
};

mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"Hand-Tether",
		new TetherProperties
		{
			colorHtml = "#ff7e00",
			tetherDuration = 18,
		}
	},
	{
		"PS-Chain-Mid",
		new TetherProperties
		{
			colorHtml = "#FFFFFF55",
			tetherDuration = 50,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = 7,
				maxDistance = 9,
				successEvent = new SpawnMechanicOnTetheredPlayers { referenceMechanicName = "RemoveVuln", spawnOnBoth = true },
				failEvent = new SpawnMechanicOnTetheredPlayers { referenceMechanicName = "ApplyVuln", spawnOnBoth = true }
			}
		}
	},
	{
		"PS-Chain-Far",
		new TetherProperties
		{
			colorHtml = "#FFFFFF55",
			tetherDuration = 50,
			persistentActivationDelay = 9,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = 9,
				maxDistance = 100,
				successEvent = new SpawnMechanicOnTetheredPlayers { referenceMechanicName = "RemoveVuln", spawnOnBoth = true },
				failEvent = new SpawnMechanicOnTetheredPlayers { referenceMechanicName = "ApplyVuln", spawnOnBoth = true }
			}
		}
	},
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"DoomStack",
		new SpawnMechanicOnReachStacks
		{
			statusIconPath = "Mechanics/Resources/DoomStack.png",
			statusName = "Twice-come Ruin",
			statusDescription = "Too many stacks will result in Doom.",
			referenceMechanicName = "ApplyDoom",
			requiredStacks = 2,
			maxStacks = 2,
			duration = 40,
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
		"MagicVuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/MagicVuln.png",
			statusName = "Magic Vulnerability Up",
			statusDescription = "Magic damage taken is increased.",
			damageType = "Magic",
			damageMultiplier = 10,
			duration = 0.3f,
		}
	},
	{
		"MagicVuln2",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/MagicVuln.png",
			statusName = "Magic Vulnerability Up 2",
			statusDescription = "Magic damage taken is increased.",
			damageType = "Magic",
			damageMultiplier = 10,
			duration = 0.3f,
		}
	}
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
		scale = new Vector3(15.0931f, 15.0931f, 1),
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>
		{
			new SpawnMechanicEvent { referenceMechanicName = "StartButton", position = new Vector2(0, 3) },
		}
	}
};


mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>();

mechanicData.mechanicPools["Hand-Pool"] = new List<MechanicEvent>();
for (int i = 0; i < 8; i++) {
	var r = i * 45;
	mechanicData.mechanicPools["Hand-Pool"].Add(new SpawnMechanicEvent{ referenceMechanicName = "SpawnHands", isPositionRelative = true, isRotationRelative = true, rotation = r });
}

var offsetA = 90 + 22.5f;
var offsetB = 180 + 90 + 22.5f;
var offsetC = 180;
var towerPoolNear = new List<MechanicEvent>{
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>()
		{
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = 45 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true, rotation = 135 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = 225 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true, rotation = 270},
		}
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>()
		{
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true, rotation = 180 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetC + 45 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true, rotation = offsetC + 135 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetC + 225 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true, rotation = offsetC + 270},
		}
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>()
		{
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetA },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetA + 45 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true, rotation = offsetA + 135 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetA + 180 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetA + 225 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true, rotation = offsetA + 270 },
		}
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>()
		{
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetB },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetB + 45 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true, rotation = offsetB + 135 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetB + 180 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-1", isPositionRelative = true, isRotationRelative = true, rotation = offsetB + 225 },
			new SpawnMechanicEvent { referenceMechanicName = "Tower-Offset-2", isPositionRelative = true, isRotationRelative = true, rotation = offsetB + 270 },
		}
	},
};

mechanicData.mechanicPools["Tower-Pool-Near"] = towerPoolNear;


var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();

}

public static class Ex
{
	public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
	{
		return k == 0 ? new[] { new T[0] } :
		  elements.SelectMany((e, i) =>
			elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] { e }).Concat(c)));
	}
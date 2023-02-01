<Query Kind="Statements">
  <Reference>D:\src\Unity\xiv-sim\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "RunDeltaDemo_Incomplete";
var baseOutputPath = @"D:\src\Unity\xiv-sim";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

var chainDistanceThreshold = 2.66f;

var groupA = new TargetSpecificPlayerIds { targetIds = new List<int> { 0, 1, 2, 3 } };
var groupB = new TargetSpecificPlayerIds { targetIds = new List<int> { 4, 5, 6, 7 } };
var screenTarget = new TargetSpecificPlayerIds { targetIds = new List<int> { 0 } };
var nearTarget = new TargetSpecificPlayerIds { targetIds = new List<int> { 1 } };
var farTarget = new TargetSpecificPlayerIds { targetIds = new List<int> { 2 } };
var tetherIdx = new List<int> {0, 1, 2, 3};

var nearWorldTarget = new TargetSpecificProximityPlayers
{
	targetIds = new List<int> { 1 },
	targetCondition = new CheckPlayerStatus { invertStatus = true, statusName = "DynamisNear" },
	fallbackTargetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int> { 1 } },
	totalTargetsNeeded = 1,
};

var farWorldTarget = new TargetSpecificProximityPlayers
{
	targetIds = new List<int> { 0 }, targetNthFarthest = true,
	targetCondition = new CheckPlayerStatus { invertStatus = true, statusName = "DynamisFar" },
	fallbackTargetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int> { 0 }, targetNthFarthest = true },
	totalTargetsNeeded = 1,
};

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
					new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses" },

					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Blue", targetingScheme = groupA, tetherIndices = tetherIdx },
					new SpawnTethersBetweenPlayers { referenceTetherName = "Chain-Green", targetingScheme = groupB, tetherIndices = tetherIdx },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyBlueTether", targetingScheme = groupA },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyGreenTether", targetingScheme = groupB },
					new ExecuteRandomEvents { mechanicPoolName = "Oversampled-Player-Pool" },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyNearWorld", targetingScheme = nearTarget },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyDistantWorld", targetingScheme = farTarget },

					new WaitEvent { timeToWait = 10 },
					new ReshufflePlayerIds(),
					
					new SpawnTargetedEvents { referenceMechanicName = "ApplyBlueFist", targetingScheme = groupA, spawnOnTarget = true },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyYellowFist", targetingScheme = groupB, spawnOnTarget = true },
					
					new WaitEvent { timeToWait = 5 },
					new ExecuteRandomEvents { mechanicPoolName = "Spinny-Pool-0" },
					new ExecuteRandomEvents { mechanicPoolName = "Spinny-Pool-1" },
					new ExecuteRandomEvents { mechanicPoolName = "Spinny-Pool-2" },
					new ExecuteRandomEvents { mechanicPoolName = "Spinny-Pool-3" },
					new ExecuteRandomEvents { mechanicPoolName = "Spinny-Pool-4" },
					new ExecuteRandomEvents { mechanicPoolName = "Spinny-Pool-5" },

					new WaitEvent { timeToWait = 6 },
				}
			}
		}
	},
	{
		"EyeMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyMovement { movementTime = -1, position = new Vector2(0, 0) },
					new WaitEvent { timeToWait = 16 },
					new StartCastBar { castName = "Eye Laser", duration = 4 },
					new WaitEvent { timeToWait = 4 },
					new SpawnMechanicEvent { referenceMechanicName = "EyeLaser", isPositionRelative = true, isRotationRelative = true },

					new WaitEvent { timeToWait = float.PositiveInfinity }
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
					new SetEnemyMovement { movementTime = -1, position = new Vector2(0, 0) },
					new WaitEvent { timeToWait = 22 },
					new ExecuteRandomEvents { mechanicPoolName = "Oversampled-Pool" },
					
					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"OmegaMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyMovement { movementTime = -1, position = new Vector2(0, 0) },
					new WaitEvent { timeToWait = 36 },
					new ExecuteRandomEvents { mechanicPoolName = "SwivelCannon-Pool" },

					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"OmegaMMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 22 },
					new ExecuteRandomEvents { mechanicPoolName = "BeyondDefense-Pool" },
					new WaitEvent { timeToWait = 9.8f },
					new SpawnTargetedEvents { referenceMechanicName = "PilePitch", targetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int> {0} }, spawnOnTarget = true },
					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"BeyondDefense1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new StartCastBar { castName = "Beyond Defense", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SetEnemyMovement { movementTime = 0.2f, moveToTarget = new TargetSpecificProximityPlayers { targetIds = new List<int> {0} } },
					new SpawnTargetedEvents { referenceMechanicName = "BeyondDefense", targetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int> {0} }, spawnOnTarget = true },
				}
			}
		}
	},
	{
		"BeyondDefense2",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new StartCastBar { castName = "Beyond Defense", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SetEnemyMovement { movementTime = 0.2f, moveToTarget = new TargetSpecificProximityPlayers { targetIds = new List<int> {1} } },
					new SpawnTargetedEvents { referenceMechanicName = "BeyondDefense", targetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int> {1} }, spawnOnTarget = true },
				}
			}
		}
	},
	{
		"ApplyBlueFist",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents { referenceMechanicName = "BlueFistVfx", isPositionRelative = true, isRotationRelative = true, targetingScheme = new TargetExistingTarget(), spawnOnTarget = true },
					new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = "BlueFistTarget" } },
				}
			}
		}
	},
	{
		"BlueFistVfx",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#008aff", visualDuration = 12, relativePosition = new Vector3(0, 0.8f, -0.8f), scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 0, 0) },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#008aff", visualDuration = 12, relativePosition = new Vector3(0, 0.8f, -0.8f), scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 90, 0) },
				}
			}
		}
	},
	{
		"ApplyYellowFist",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents { referenceMechanicName = "YellowFistVfx", isPositionRelative = true, isRotationRelative = true, targetingScheme = new TargetExistingTarget(), spawnOnTarget = true },
					new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = "YellowFistTarget" } },
				}
			}
		}
	},
	{
		"YellowFistVfx",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff9000", visualDuration = 12, relativePosition = new Vector3(0, 0.8f, -0.8f), scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 0, 0) },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff9000", visualDuration = 12, relativePosition = new Vector3(0, 0.8f, -0.8f), scale = new Vector3(0.5f, 0.5f, 1), eulerAngles = new Vector3(0, 90, 0) },
				}
			}
		}
	},
	{
		"Oversampled-PlayerRight",
		new MechanicProperties
		{
			visible = false,
			isTargeted = true,
			followSpeed = 10,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 22 },
					new SpawnVisualObject {
						textureFilePath = "Mechanics/Resources/Screens.png",
						visualDuration = 10, colorHtml = "#0486ff",
						relativePosition = new Vector3(1, 0.5f, 0),
						isBillboard = true,
						scale = Vector3.one,
						spawnOnPlayer = true,
					},
					new WaitEvent { timeToWait = 10 },
					new SpawnMechanicEvent { referenceMechanicName = "Oversampled-Target-Player", isPositionRelative = true, isRotationRelative = true, rotation = 90 }
				}
			}
		}
	},
	{
		"Oversampled-PlayerLeft",
		new MechanicProperties
		{
			visible = false,
			isTargeted = true,
			followSpeed = 10,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 22 },
					new SpawnVisualObject {
						textureFilePath = "Mechanics/Resources/Screens.png",
						visualDuration = 10, colorHtml = "#0486ff",
						relativePosition = new Vector3(-1, 0.5f, 0),
						isBillboard = true,
						scale = Vector3.one,
						spawnOnPlayer = true,
					},
					new WaitEvent { timeToWait = 10 },
					new SpawnMechanicEvent { referenceMechanicName = "Oversampled-Target-Player", isPositionRelative = true, isRotationRelative = true, rotation = -90 }
				}
			}
		}
	},
	{
		"Oversampled-Target-Player",
		new MechanicProperties
		{
			visible = false,
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(50, 50),
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent> {
					new WaitEvent {timeToWait = 0.2f },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "Oversampled",
						spawnOnTarget = true,
						targetingScheme = new TargetPlayersInsideAoe { totalTargetsNeeded = 2 }
					},
				}
			}
		}
	},
	{
		"Oversampled-Target",
		new MechanicProperties
		{
			visible = false,
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(50, 50),
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new StartCastBar { castName = "Oversampled Wave Cannon", duration = 10 },
					new SpawnVisualObject {
						textureFilePath = "Mechanics/Resources/Screens.png",
						visualDuration = 10, colorHtml = "#0486ff",
						relativePosition = new Vector3(0, 3, 3),
						eulerAngles = new Vector3(0, 0, 0),
						scale = Vector3.one * 3
					},
					new WaitEvent { timeToWait = 10 },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "Oversampled",
						spawnOnTarget = true,
						targetingScheme = new TargetPlayersInsideAoe { totalTargetsNeeded = 2 }
					}
				}
			} 
		}
	},
	{
		"Oversampled",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2.33f, 360),
			colorHtml = "#9ccfff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 50000, damageType = "Magic", name = "Oversampled Wave Cannon" },
							new ApplyStatusEffect { referenceStatusName = "DoomStack" }
						}
					}
				}
			}
		}
	},
	{
		"BeyondDefense",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.66f, 360),
			colorHtml = "#fff600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 50000, damageType = "Magic", name = "Beyond Defense" },
							new ApplyStatusEffect { referenceStatusName = "DoomStack" }
						}
					}
				}
			}
		}
	},
	{
		"PilePitch",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 360),
			colorHtml = "#cc90ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 200000, damageType = "Magic", name = "Pile Pitch", maxStackAmount = 3 },
							new ApplyStatusEffect { referenceStatusName = "DoomStack" }
						}
					}
				}
			}
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
							new DamageEffect { damageAmount = 50000, damageType = "Magic", name = "Patch" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" }
						}
					}
				}
			}
		}
	},
	{
		"FistAoeBlue",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#008aff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Physical", name = "Fist AOE" },
						}
					}
				}
			}
		}
	},
	{
		"FistAoeYellow",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#ff9000",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Physical", name = "Fist AOE" },
						}
					}
				}
			}
		}
	},
	{
		"NearWorldSmall",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.33f, 360),
			colorHtml = "#00ff00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 30000, damageType = "Magic", name = "Hello Near World" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln", overrideDuration = 5 },
							new ApplyStatusEffect { referenceStatusName = "DynamisNear" },
						}
					},
					new WaitEvent { timeToWait = 0.2f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisibleFalse" },
					new WaitEvent { timeToWait = 0.6f },
					new CheckMechanicDepth {
						expressionFormat = "{0} < 2",
						successEvent = new SpawnTargetedEvents { referenceMechanicName = "NearWorldSmall", targetingScheme = nearWorldTarget, spawnOnTarget = true, isPositionRelative = true, isRotationRelative = true }
					},
				}
			}
		}
	},
	{
		"NearWorldLarge",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2.66f, 360),
			colorHtml = "#00ff00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 30000, damageType = "Magic", name = "Hello Near World" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln", overrideDuration = 5 },
							new ApplyStatusEffect { referenceStatusName = "DynamisNear" },
						}
					},
					new WaitEvent { timeToWait = 0.2f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisibleFalse" },
					new WaitEvent { timeToWait = 0.6f },
					new SpawnTargetedEvents { referenceMechanicName = "NearWorldSmall", resetMechanicDepth = true, targetingScheme = nearWorldTarget, spawnOnTarget = true, isPositionRelative = true, isRotationRelative = true  }
				}
			}
		}
	},
	{
		"DistantWorldSmall",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.33f, 360),
			colorHtml = "#0000ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 30000, damageType = "Magic", name = "Hello Distant World" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln", overrideDuration = 5 },
							new ApplyStatusEffect { referenceStatusName = "DynamisFar" },
						}
					},
					new WaitEvent { timeToWait = 0.2f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisibleFalse" },
					new WaitEvent { timeToWait = 0.6f },
					new CheckMechanicDepth {
						expressionFormat = "{0} < 2",
						successEvent = new SpawnTargetedEvents { referenceMechanicName = "DistantWorldSmall", targetingScheme = farWorldTarget, spawnOnTarget = true, isPositionRelative = true, isRotationRelative = true }
					},
				}
			}
		}
	},
	{
		"DistantWorldLarge",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2.66f, 360),
			colorHtml = "#0000ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 30000, damageType = "Magic", name = "Hello Distant World" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln", overrideDuration = 5 },
							new ApplyStatusEffect { referenceStatusName = "DynamisFar" },
						}
					},
					new WaitEvent { timeToWait = 0.2f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisibleFalse" },
					new WaitEvent { timeToWait = 0.6f },
					new SpawnTargetedEvents { referenceMechanicName = "DistantWorldSmall", resetMechanicDepth = true, targetingScheme = farWorldTarget, spawnOnTarget = true, isPositionRelative = true, isRotationRelative = true  }
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
		"SpinnyLaserAddCW",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent> {
					new WaitEvent { timeToWait = 2 },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/ArrowCircle.png", visualDuration = 10, colorHtml = "#ff9000", relativePosition = new Vector3(0, 0.5f, 0), scale = Vector3.one * 3, eulerAngles = new Vector3(-90, 0, 0), isRotationRelative = false },
					new WaitEvent { timeToWait = 9.5f },
					new SetEnemyMovement { movementTime = -0.5f, moveToTarget = new TargetSpecificProximityPlayers { targetIds = new List<int> {0} } },
					new WaitEvent { timeToWait = 0.5f },
					new SpawnMechanicEvent { referenceMechanicName = "SpinnyIndicatorCW", isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"SpinnyLaserAddCCW",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent> {
					new WaitEvent { timeToWait = 2 },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/ArrowCircle.png", visualDuration = 10, colorHtml = "#008aff", relativePosition = new Vector3(0, 0.5f, 0), scale = Vector3.one * 3, eulerAngles = new Vector3(90, 0, 0), isRotationRelative = false },
					new WaitEvent { timeToWait = 9.5f },
					new SetEnemyMovement { movementTime = -0.5f, moveToTarget = new TargetSpecificProximityPlayers { targetIds = new List<int> {0} } },
					new WaitEvent { timeToWait = 0.5f },
					new SpawnMechanicEvent { referenceMechanicName = "SpinnyIndicatorCCW", isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"SpawnSpinnyCW",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Spinny",
				textureFilePath = "Mechanics/Resources/Hand.png",
				colorHtml = "#000000",
				maxHp = 35000000,
				baseMoveSpeed = 0,
				hitboxSize = 10,
				visualPosition = new Vector3(0, 1, 0),
				visualScale = Vector3.one,
				referenceMechanicName = "SpinnyLaserAddCW",
				position = new Vector2(0, 6.66f),
				isPositionRelative = true,
				isRotationRelative = true,
				isTargetable = false,
			},
		}
	},
	{
		"SpawnSpinnyCCW",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Spinny",
				textureFilePath = "Mechanics/Resources/Hand.png",
				colorHtml = "#000000",
				maxHp = 35000000,
				baseMoveSpeed = 0,
				hitboxSize = 10,
				visualPosition = new Vector3(0, 1, 0),
				visualScale = Vector3.one,
				referenceMechanicName = "SpinnyLaserAddCCW",
				position = new Vector2(0, 6.66f),
				isPositionRelative = true,
				isRotationRelative = true,
				isTargetable = false,
			},
		}
	},
	{
		"EyeLaser",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(30, 5.33f),
			colorHtml = "#ff0000",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Magic", name = "Eye Laser" },
						}
					}
				}
			}
		}
	},
	{
		"SwivelCannon-Cast",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent>
				{
					new StartCastBar { castName = "Swivel Cannon", duration = 10 },
					new SpawnVisualObject {
						textureFilePath = "Mechanics/Resources/Screens.png",
						visualDuration = 10, colorHtml = "#ff9000",
						relativePosition = new Vector3(0, 3, 3),
						eulerAngles = new Vector3(0, 0, 0),
						scale = Vector3.one * 3
					},
					new WaitEvent { timeToWait = 7 },
					new SpawnMechanicEvent { referenceMechanicName = "SwivelCannon", isPositionRelative = true, isRotationRelative = true }
				}
			}
		}
	},
	{
		"SwivelCannon",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(50, 210),
			colorHtml = "#ff9000",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Magic", name = "Swivel Cannon" },
						}
					}
				}
			}
		}
	},
	{
		"SpinnyIndicatorCCW",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(30, 2.66f),
			colorHtml = "#ff9000",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Magic", name = "Spinny Laser" },
						}
					},
					new SpawnMechanicEvent { referenceMechanicName = "SpinnyLaserCCW", isPositionRelative = true, isRotationRelative = true, resetMechanicDepth = true }
				}
			}
		}
	},
	{
		"SpinnyIndicatorCW",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(30, 2.66f),
			colorHtml = "#ff9000",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Magic", name = "Spinny Laser" },
						}
					},
					new SpawnMechanicEvent { referenceMechanicName = "SpinnyLaserCW", isPositionRelative = true, isRotationRelative = true, resetMechanicDepth = true }
				}
			}
		}
	},
	{
		"SpinnyLaserCCW",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(30, 2.66f),
			colorHtml = "#ff9000",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Magic", name = "Spinny Laser" },
						}
					},
					new WaitEvent { timeToWait = 0.2f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisibleFalse" },
					new WaitEvent { timeToWait = 0.1f },
					new CheckMechanicDepth {
						expressionFormat = "{0} < 6",
						successEvent = new SpawnMechanicEvent { referenceMechanicName = "SpinnyLaserCCW", isPositionRelative = true, isRotationRelative = true, rotation = -15 }
					},
				}
			}
		}
	},
	{
		"SpinnyLaserCW",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(30, 2.66f),
			colorHtml = "#ff9000",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Magic", name = "Spinny Laser" },
						}
					},
					new WaitEvent { timeToWait = 0.2f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisibleFalse" },
					new WaitEvent { timeToWait = 0.1f },
					new CheckMechanicDepth {
						expressionFormat = "{0} < 6",
						successEvent = new SpawnMechanicEvent { referenceMechanicName = "SpinnyLaserCW", isPositionRelative = true, isRotationRelative = true, rotation = 15 }
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
					new SpawnEnemy {
						enemyName = "FinalOmega",
						textureFilePath = "Mechanics/Resources/UltimaWeapon.png",
						colorHtml = "#0a4d8b",
						maxHp = 35000000,
						baseMoveSpeed = 0,
						hitboxSize = 10,
						visualPosition = new Vector3(0, 2, 0),
						visualScale = Vector3.one * 4,
						referenceMechanicName = "FinalOmegaMechanics",
						position = new Vector2(0, 6.66f),
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
					},
					new SpawnEnemy {
						enemyName = "Optical Unit",
						textureFilePath = "Mechanics/Resources/Eye.png",
						colorHtml = "#0a4d8b",
						maxHp = 35000000,
						baseMoveSpeed = 0,
						hitboxSize = 10,
						visualPosition = new Vector3(0, 2, 0),
						visualScale = Vector3.one * 4,
						referenceMechanicName = "EyeMechanics",
						position = new Vector2(6.66f, 0),
						rotation = 90,
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
					},
					new SpawnEnemy {
						enemyName = "Omega-M",
						textureFilePath = "Mechanics/Resources/OmegaM.png",
						colorHtml = "#0a4d8b",
						maxHp = 35000000,
						baseMoveSpeed = 0,
						hitboxSize = 10,
						visualPosition = new Vector3(0, 1.5f, 0),
						visualScale = Vector3.one * 2,
						referenceMechanicName = "OmegaMMechanics",
						position = new Vector2(0, 0),
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
					},
					new SpawnEnemy {
						enemyName = "Omega",
						textureFilePath = "Mechanics/Resources/Omega.png",
						colorHtml = "#0a4d8b",
						maxHp = 35000000,
						baseMoveSpeed = 0,
						hitboxSize = 10,
						visualPosition = new Vector3(0, 1.5f, 0),
						visualScale = Vector3.one * 2,
						referenceMechanicName = "OmegaMechanics",
						position = new Vector2(0, -6.66f),
						isPositionRelative = true,
						isRotationRelative = true,
						isTargetable = false,
					}
				}
			}
		}
	},
	{
		"ApplyGreenTether",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "GreenTether" }
			}
		}
	},
	{
		"ApplyBlueTether",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "BlueTether" }
			}
		}
	},
	{
		"ApplyNearWorld",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "NearWorld" }
			}
		}
	},
	{
		"ApplyDistantWorld",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "DistantWorld" }
			}
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
};

mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"Chain-Blue",
		new TetherProperties
		{
			colorHtml = "#0000ff55",
			tetherDuration = 30,
			persistentActivationDelay = 18,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = -1,
				maxDistance = chainDistanceThreshold,
				successEvent = new ModifyTetherProperties { referenceTetherName = "Chain-Blue-Active" },
				failEvent = new EndTether { shouldTriggerBreakEvent = true }
			},
			breakMechanic = new SpawnMechanicOnTetheredPlayers {
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
		"Chain-Green",
		new TetherProperties
		{
			colorHtml = "#00ff0055",
			tetherDuration = 54,
			persistentActivationDelay = 18,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = chainDistanceThreshold,
				maxDistance = 999,
				successEvent = new ModifyTetherProperties { referenceTetherName = "Chain-Green-Active" },
				failEvent = new EndTether { shouldTriggerBreakEvent = true }
			},
			breakMechanic = new SpawnMechanicOnTetheredPlayers {
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
		"DoomStack",
		new SpawnMechanicOnReachStacks
		{
			statusIconPath = "Mechanics/Resources/DoomStack.png",
			statusName = "Twice-come Ruin",
			statusDescription = "Too many stacks will result in Doom.",
			referenceMechanicName = "ApplyDoom",
			requiredStacks = 2,
			maxStacks = 2,
			duration = 5,
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
			duration = 1,
		}
	},
	{
		"BlueFistTarget",
		new SpawnMechanicOnExpire
		{
			statusName = "Blue Fist Target (Fake)",
			statusDescription = "Fists aren't supported yet so just pretend.",
			duration = 12,
			referenceMechanicName = "FistAoeBlue",
		}
	},
	{
		"YellowFistTarget",
		new SpawnMechanicOnExpire
		{
			statusName = "Yellow Fist Target (Fake)",
			statusDescription = "Fists aren't supported yet so just pretend.",
			duration = 12,
			referenceMechanicName = "FistAoeYellow",
		}
	},
	{
		"GreenTether",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/NearTether1.png",
			statusName = "Green Tether",
			duration = 18,
			allowDuplicates = true,
		}
	},
	{
		"BlueTether",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/FarTether1.png",
			statusName = "Blue Tether",
			duration = 18,
			allowDuplicates = true
		}
	},
	{
		"NearWorld",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/NearWorld.png",
			statusName = "Hello Near World",
			statusDescription = "",
			duration = 44,
			referenceMechanicName = "NearWorldLarge",
		}
	},
	{
		"DistantWorld",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/DistantWorld.png",
			statusName = "Hello Distant World",
			statusDescription = "",
			duration = 44,
			referenceMechanicName = "DistantWorldLarge",
		}
	},
	{
		"DynamisNear",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/NisiA.png",
			statusName = "DynamisNear",
			statusDescription = "Hidden debuff to prevent being targeted by near world",
			duration = 99,
		}
	},
	{
		"DynamisFar",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/NisiD.png",
			statusName = "DynamisFar",
			statusDescription = "Hidden debuff to prevent being targeted by far world",
			duration = 99,
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

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"Oversampled-Pool",
		new List<MechanicEvent> {
			new SpawnMechanicEvent { referenceMechanicName = "Oversampled-Target", isPositionRelative = true, isRotationRelative = true, rotation = 90 },
			new SpawnMechanicEvent { referenceMechanicName = "Oversampled-Target", isPositionRelative = true, isRotationRelative = true, rotation = -90 },
		}
	},
	{
		"Oversampled-Player-Pool",
		new List<MechanicEvent> {
			new SpawnTargetedEvents { referenceMechanicName = "Oversampled-PlayerLeft", isPositionRelative = true, isRotationRelative = true, rotation = 90, targetingScheme = screenTarget },
			new SpawnTargetedEvents { referenceMechanicName = "Oversampled-PlayerRight", isPositionRelative = true, isRotationRelative = true, rotation = -90, targetingScheme = screenTarget },
		}
	},
	{
		"BeyondDefense-Pool",
		new List<MechanicEvent> {
			new SpawnMechanicEvent { referenceMechanicName = "BeyondDefense1", isPositionRelative = true, isRotationRelative = true },
			new SpawnMechanicEvent { referenceMechanicName = "BeyondDefense2", isPositionRelative = true, isRotationRelative = true }
		}
	},
	{
		"SwivelCannon-Pool",
		new List<MechanicEvent> {
			new SpawnMechanicEvent { referenceMechanicName = "SwivelCannon-Cast", isPositionRelative = true, isRotationRelative = true, rotation = 90 },
			new SpawnMechanicEvent { referenceMechanicName = "SwivelCannon-Cast", isPositionRelative = true, isRotationRelative = true, rotation = -90 }
		}
	}
};

for (int i = 0; i < 6; i++)
{
	mechanicData.mechanicPools[$"Spinny-Pool-{i}"] =
	new List<MechanicEvent> {
		new SpawnMechanicEvent { referenceMechanicName = "SpawnSpinnyCW", isPositionRelative = true, rotation = 30 + i * 60 },
		new SpawnMechanicEvent { referenceMechanicName = "SpawnSpinnyCCW", isPositionRelative = true, rotation = 30 + i * 60 }
	};
}

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
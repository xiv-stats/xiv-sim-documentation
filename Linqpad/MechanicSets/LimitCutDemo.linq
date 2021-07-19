<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "LimitCutDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

var hawkBlasterGap = 2.2f;

var limitcutGap = 1.8f;
var alphaSwordDelay = 1.0f;
var blasstyChargeDelay = 1.7f;

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"HawkBlasterSequence",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 180 },
					new WaitEvent { timeToWait = hawkBlasterGap },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 45 },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 225 },
					new WaitEvent { timeToWait = hawkBlasterGap },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 90 },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 270 },
					new WaitEvent { timeToWait = hawkBlasterGap },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 135 },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 315 },
					new WaitEvent { timeToWait = hawkBlasterGap },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlaster" },
					new WaitEvent { timeToWait = hawkBlasterGap },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 180 },
					new WaitEvent { timeToWait = hawkBlasterGap },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 45 },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 225 },
					new WaitEvent { timeToWait = hawkBlasterGap },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 90 },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 270 },
					new WaitEvent { timeToWait = hawkBlasterGap },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 135 },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterOffset", isRotationRelative = true, rotation = 315 },
					new WaitEvent { timeToWait = hawkBlasterGap },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlaster" },
				}
			}
		}
	},
	{
		"HawkBlasterOffset",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnMechanicEvent { referenceMechanicName = "HawkBlaster", position = new Vector2(5.9f, 0), isPositionRelative = true, isRotationRelative = true }
		}
	},
	{
		"HawkBlaster",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(4.2f, 360),
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 400000, damageType = "Magic", name = "Hawk Blaster" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" }
						}
					},
					new WaitEvent { timeToWait = 1 },
					new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterVisual", isPositionRelative = true }
				}
			}
		}
	},
	{
		"HawkBlasterVisual",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(4.2f, 360),
			colorHtml = "#ff5a00",
			visible = true,
			mechanic = new WaitEvent { timeToWait = 0.2f },
		}
	},
	{
		"Spawn-CruiseChaser-LC",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Cruise Chaser",
				textureFilePath = "Mechanics/Resources/CruiseChaser.png",
				colorHtml = "#8b4800",
				maxHp = int.MaxValue,
				baseMoveSpeed = 2,
				hitboxSize = 2,
				visualPosition = new Vector3(0, 1, 0),
				visualScale = Vector3.one * 2,
				referenceMechanicName = "LimitCutSequence",
				isTargetable = false,
				showInEnemyList = false,
				isVisible = false,
			},
		}
	},
	{
		"LimitCutSequence",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents { referenceMechanicName = "LimitCutMarker-1", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{0}, dropExtraEvents = true } },
					new SpawnTargetedEvents { referenceMechanicName = "LimitCutMarker-2", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{1}, dropExtraEvents = true } },
					new SpawnTargetedEvents { referenceMechanicName = "LimitCutMarker-3", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{2}, dropExtraEvents = true } },
					new SpawnTargetedEvents { referenceMechanicName = "LimitCutMarker-4", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{3}, dropExtraEvents = true } },
					new SpawnTargetedEvents { referenceMechanicName = "LimitCutMarker-5", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{4}, dropExtraEvents = true } },
					new SpawnTargetedEvents { referenceMechanicName = "LimitCutMarker-6", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{5}, dropExtraEvents = true } },
					new SpawnTargetedEvents { referenceMechanicName = "LimitCutMarker-7", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{6}, dropExtraEvents = true } },
					new SpawnTargetedEvents { referenceMechanicName = "LimitCutMarker-8", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int>{7}, dropExtraEvents = true } },
					new WaitEvent { timeToWait = 2 },
					new ExecuteRandomEvents { mechanicPoolName = "Hawkblaster-Pool" },
					new WaitEvent { timeToWait = 6 },
					new SetEnemyMovement { movementTime = 0.01f, moveToTarget = new TargetSpecificPlayerIds { targetIds = new List<int>{0} }, position = new Vector3(0, -1) },
					new WaitEvent { timeToWait = 0.01f },
					new SetEnemyMovement { movementTime = -1, moveToTarget =new TargetSpecificPlayerIds { targetIds = new List<int>{0} } },
					new SetEnemyVisible { visible = true },
					new WaitEvent { timeToWait = alphaSwordDelay },
					new SpawnTargetedEvents { referenceMechanicName = "AlphaSword", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} } },
					new WaitEvent { timeToWait = blasstyChargeDelay },
					new SpawnTargetedEvents { referenceMechanicName = "BlasstyCharge", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {1} } },
					new SetEnemyVisible { visible = false },

					new WaitEvent { timeToWait = limitcutGap },
					new SetEnemyMovement { movementTime = 0.01f, moveToTarget = new TargetSpecificPlayerIds { targetIds = new List<int>{2} }, position = new Vector3(0, -1) },
					new WaitEvent { timeToWait = 0.01f },
					new SetEnemyMovement { movementTime = -1, moveToTarget =new TargetSpecificPlayerIds { targetIds = new List<int>{2} } },
					new SetEnemyVisible { visible = true },
					new WaitEvent { timeToWait = alphaSwordDelay },
					new SpawnTargetedEvents { referenceMechanicName = "AlphaSword", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {2} } },
					new WaitEvent { timeToWait = blasstyChargeDelay },
					new SpawnTargetedEvents { referenceMechanicName = "BlasstyCharge", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {3} } },
					new SetEnemyVisible { visible = false },

					new WaitEvent { timeToWait = limitcutGap },
					new SetEnemyMovement { movementTime = 0.01f, moveToTarget = new TargetSpecificPlayerIds { targetIds = new List<int>{4} }, position = new Vector3(0, -1) },
					new WaitEvent { timeToWait = 0.01f },
					new SetEnemyMovement { movementTime = -1, moveToTarget =new TargetSpecificPlayerIds { targetIds = new List<int>{4} } },
					new SetEnemyVisible { visible = true },
					new WaitEvent { timeToWait = alphaSwordDelay },
					new SpawnTargetedEvents { referenceMechanicName = "AlphaSword", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {4} } },
					new WaitEvent { timeToWait = blasstyChargeDelay },
					new SpawnTargetedEvents { referenceMechanicName = "BlasstyCharge", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {5} } },
					new SetEnemyVisible { visible = false },

					new WaitEvent { timeToWait = limitcutGap },
					new SetEnemyMovement { movementTime = 0.01f, moveToTarget = new TargetSpecificPlayerIds { targetIds = new List<int>{6} }, position = new Vector3(0, -1) },
					new WaitEvent { timeToWait = 0.01f },
					new SetEnemyMovement { movementTime = -1, moveToTarget =new TargetSpecificPlayerIds { targetIds = new List<int>{6} } },
					new SetEnemyVisible { visible = true },
					new WaitEvent { timeToWait = alphaSwordDelay },
					new SpawnTargetedEvents { referenceMechanicName = "AlphaSword", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {6} } },
					new WaitEvent { timeToWait = blasstyChargeDelay },
					new SpawnTargetedEvents { referenceMechanicName = "BlasstyCharge", isPositionRelative = true, targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {7} } },
					new SetEnemyVisible { visible = false },
				}
			}
		}
	},
	{
		"SetVisible",
		new MechanicProperties {
			visible = true,
		}
	},
	{
		"AlphaSword",
		new MechanicProperties
		{
			collisionShapeParams = new Vector4(10, 90),
			colorHtml = "#ffff00",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers
					{
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 50000, damageType = "Physical", name = "Alpha Sword" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" },
							new KnockbackEffect { knockbackDistance = 2, canArmsLength = true }
						}
					}
				}
			}
		}
	},
	{
		"BlasstyCharge",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(40, 3),
			colorHtml = "#ffff00",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers
					{
						condition = new CheckPlayerFacingAway(),
						effects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 45000, damageType = "Physical", name = "Super Blassty Charge" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" },
							new KnockbackEffect { knockbackDistance = 10, canArmsLength = true }
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect {damageAmount = 45000, damageType = "Physical", name = "Super Blassty Charge" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" },
						},
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
			collisionShapeParams = new Vector4(25, 360, 7),
			colorHtml = "#8800FF",
			persistentTickInterval = 0.2f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage" } },
		}
	},
};

for (int i = 1; i <= 8; i++)
{
	var scale = Vector3.one * 0.5f;
	if (i == 5) {
		scale = new Vector3(1.78f, 1, 1) * 0.5f;
	}
	else if (i > 5)
	{
		scale = new Vector3(2.16f, 1, 1) * 0.5f;
	}
	mechanicData.referenceMechanicProperties[$"LimitCutMarker-{i}"] = new MechanicProperties {
		visible = false,
		mechanic = new SpawnVisualObject {
			textureFilePath = $"Mechanics/Resources/LimitCut-{i}.png",
			colorHtml = i % 2 == 0 ? "#ff0000" : "#0000ff",
			visualDuration = 8,
			scale = scale,
			relativePosition = Vector3.up,
			isBillboard = true,
			spawnOnPlayer = true,
		}
	};
}

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
			damageMultiplier = 8,
			duration = 10,
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
			damageMultiplier = 8,
			duration = 17,
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
		scale = new Vector3(15.8637f, 15.8637f, 1),
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>
		{
			new WaitEvent { timeToWait = 2},
			new SpawnMechanicEvent { referenceMechanicName = "Spawn-CruiseChaser-LC" },
		}
	}
};
mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"Hawkblaster-Pool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterSequence"},
			new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterSequence", rotation = 45 },
			new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterSequence", rotation = 90 },
			new SpawnMechanicEvent { referenceMechanicName = "HawkBlasterSequence", rotation = 135 },
		}
	},
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
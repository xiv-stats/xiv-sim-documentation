<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "WyrmholeDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

var mechanicData = new MechanicData();

float ScaleToSim(float gameScale)
{
	return gameScale / 3f;
}

var gnashAndLashCastTime = 7.6f;

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"NidhoggMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitForAggro(),
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro(), isPositionRelative = true },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro(), isPositionRelative = true },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro(), isPositionRelative = true },
					new WaitEvent { timeToWait = 3 },

					new SetEnemyBaseSpeed { baseMoveSpeed = 0 },
					new StartCastBar { castName = "Dive from Grace", duration = 5},
					new ExecuteRandomEvents { mechanicPoolName = "Debuffs1" },
					new ExecuteRandomEvents { mechanicPoolName = "Debuffs2" },


					new WaitEvent { timeToWait = 4.9f },
					new StartCastBar { castName = "", duration = 100000 },
					new WaitEvent { timeToWait = 1.9f },
					new ExecuteRandomEvents { mechanicPoolName = "InOutPool" },
					new WaitEvent { timeToWait = gnashAndLashCastTime - 0.1f },
					new StartCastBar { castName = "", duration = 100000 },
					new WaitEvent { timeToWait = 1.1f },
					new SpawnMechanicEvent { referenceMechanicName = "Stack-Target", isPositionRelative = true, isRotationRelative = true },

					new WaitEvent { timeToWait = 13f },
					new ExecuteRandomEvents { mechanicPoolName = "InOutPool" },
					new WaitEvent { timeToWait = gnashAndLashCastTime - 0.1f },
					new StartCastBar { castName = "", duration = 100000 },
					new WaitEvent { timeToWait = 1.1f },
					new SpawnMechanicEvent { referenceMechanicName = "Stack-Target", isPositionRelative = true, isRotationRelative = true },

					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"Group1-A",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents {referenceMechanicName = "Spineshatter-1", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{0}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "Elusive-1", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{1}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-1", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{2}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-3", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{3}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-3", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{4}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-3", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{5}, targetLivingOnly = false}}
				}
			}
		}
	},
	{
		"Group1-B",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-1", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{0}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-1", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{1}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-1", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{2}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "Spineshatter-3", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{3}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "Elusive-3", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{4}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-3", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{5}, targetLivingOnly = false}}
				}
			}
		}
	},
	{
		"Group2-A",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents {referenceMechanicName = "Spineshatter-2", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{6}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "Elusive-2", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{7}, targetLivingOnly = false}},
				}
			}
		}
	},
	{
		"Group2-B",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-2", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{6}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "HiJump-2", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{7}, targetLivingOnly = false}},
				}
			}
		}
	},
	{
		"TowerAddMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1.5f },
					new SetEnemyMovement
					{
						movementTime = -1,
						moveToTarget = new TargetSpecificProximityPlayers { targetIds = new List<int>{0} }
					},
					new WaitEvent { timeToWait = 0.8f },
					new StartCastBar {castName = "Geirskogul", duration = 4.5f},
					new WaitEvent { timeToWait = 4.3f },
					new SpawnMechanicEvent { referenceMechanicName = "Geirskogul", isPositionRelative = true, isRotationRelative = true }
				}
			}
		}
	},
	{
		"AutoAttack",
		new MechanicProperties {
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(20, 1),
			colorHtml = "#FF0000",
			isTargeted = true,
			followSpeed = 0,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 30000, damageType = "Damage", name = "Attack" },
					}
				}
			}
		}
	},
	{
		"Geirskogul",
		new MechanicProperties {
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(ScaleToSim(62), ScaleToSim(8)),
			colorHtml = "#ffae00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 999999, damageType = "Physical", name = "Geirskogul" },
					}
				}
			}
		}
	},
	{
		"Stack",
		new MechanicProperties {
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(ScaleToSim(6), 360),
			colorHtml = "#ff0060",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 600000, damageType = "Damage", name = "Eye of the Tyrant", maxStackAmount = 8 },
					}
				}
			}
		}
	},
	{
		"Stack-Target",
		new MechanicProperties
		{
			visible = false,
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(30, 45),
			mechanic = new SpawnTargetedEvents
			{
				referenceMechanicName = "Stack",
				spawnOnTarget = true,
				targetingScheme = new TargetPlayersInsideAoe { totalTargetsNeeded = 1 }
			}
		}
	},
	{
		"Chariot",
		new MechanicProperties {
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(ScaleToSim(8f), 360),
			colorHtml = "#c800a0",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Gnashing Wheel" },
					}
				}
			}
		}
	},
	{
		"Dynamo",
		new MechanicProperties {
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(ScaleToSim(40f), 360, ScaleToSim(8f)),
			colorHtml = "#c800a0",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Lashing Wheel" },
					}
				}
			}
		}
	},
	{
		"InOut",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new StartCastBar { castName = "Lash and Gnash", duration = gnashAndLashCastTime },
					new WaitEvent { timeToWait = gnashAndLashCastTime + 4f },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true },
					new WaitEvent { timeToWait = 2.8f },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true },
				}
			}
		}
	},
	{
		"OutIn",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new StartCastBar {castName = "Gnash and Lash", duration = gnashAndLashCastTime },
					new WaitEvent { timeToWait = gnashAndLashCastTime + 4f },
					new SpawnMechanicEvent { referenceMechanicName = "Chariot", isPositionRelative = true },
					new WaitEvent { timeToWait = 2.8f },
					new SpawnMechanicEvent { referenceMechanicName = "Dynamo", isPositionRelative = true },
				}
			}
		}
	},
	{
		"Tower-Spineshatter",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnMechanicEvent
			{
				referenceMechanicName = "Tower-HiJump",
				isPositionRelative = true,
				isRotationRelative = true,
				position = Vector3.up * 9f / 2f
			}
		}
	},
	{
		"Tower-Elusive",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnMechanicEvent
			{
				referenceMechanicName = "Tower-HiJump",
				isPositionRelative = true,
				isRotationRelative = true,
				position = Vector3.down * 9f / 2f
			}
		}
	},
	{
		"Tower-HiJump",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 4 },
					new SpawnMechanicEvent { referenceMechanicName = "Tower", isPositionRelative = true, isRotationRelative = true },
					new WaitEvent { timeToWait = 1.8f + 0.76f },
					new SpawnMechanicEvent { referenceMechanicName = "Spawn-TowerAdd", isPositionRelative = true, isRotationRelative = true }
				}
			}
		}
	},
	{
		"Tower",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(ScaleToSim(5), 360),
			colorHtml = "#FFFF00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = $"Mechanics/Resources/LimitCut-1.png", colorHtml = "#FFFF00", visualDuration = 1.8f, relativePosition = Vector3.up, isBillboard = true },
					new WaitEvent { timeToWait = 1.8f },
					new CheckNumberOfPlayers
					{
						expressionFormat = $"{{0}} > 0",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "TowerFail", isPositionRelative = true }
					},
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 40000, damageType = "Magic", name = "Darkdragon Dive" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" }
						}
					}
				}
			}
		}
	},
	{
		"TowerFail",
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
						effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage", name = "Tower Failed" }
					}
				}
			}
		}
	},
	{
		"Spawn-Nidhogg",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Nidhogg",
				textureFilePath = "Mechanics/Resources/Estinien.png",
				colorHtml = "#ff0060",
				maxHp = int.MaxValue,
				baseMoveSpeed = 3,
				hitboxSize = ScaleToSim(10.5f) * 2,
				visualPosition = new Vector3(0, 1.75f, 0),
				visualScale = Vector3.one * 3.5f,
				position = new Vector2(0, 0),
				rotation = 180,
				referenceMechanicName = "NidhoggMechanics",
				isTargetable = true,
			},
		}
	},
	{
		"Spawn-TowerAdd",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnEnemy
			{
				enemyName = "Nidhogg",
				textureFilePath = "Mechanics/Resources/Estinien.png",
				colorHtml = "#ff0060",
				maxHp = int.MaxValue,
				baseMoveSpeed = 0,
				visualPosition = new Vector3(0, 1.75f, 0),
				visualScale = Vector3.one * 2.5f,
				isPositionRelative = true,
				isRotationRelative = true,
				rotation = 180,
				referenceMechanicName = "TowerAddMechanics",
				isTargetable = false,
			},
		}
	},
	{
		"ArenaBoundary",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(30, 270),
			colorHtml = "#8800FF",

			persistentTickInterval = 0.2f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage" } },
		}
	}
};

for (int i = 1; i <= 3; i++)
{
	var scale = Vector3.one * 0.5f;
	mechanicData.referenceMechanicProperties[$"JumpMarker-{i}"] = new MechanicProperties {
		visible = false,
		mechanic = new SpawnVisualObject {
			textureFilePath = $"Mechanics/Resources/LimitCut-{i}.png",
			colorHtml = i % 2 == 0 ? "#ff0000" : "#0000ff",
			visualDuration = 5f,
			scale = scale,
			relativePosition = Vector3.up,
			isBillboard = true,
			spawnOnPlayer = true,
		}
	};
}

var jumps = new List<string> { "HiJump", "Spineshatter", "Elusive" };

foreach (var jump in jumps)
{
	for (int i = 1; i <= 3; i++)
	{
		mechanicData.referenceMechanicProperties[$"{jump}-{i}"] = new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = $"Line-{i}" } },
					new SpawnTargetedEvents { referenceMechanicName = $"JumpMarker-{i}", targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 5.5f },
					new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = $"{jump}-{i}" } },
				}
			}
		};
	}
	mechanicData.referenceMechanicProperties[$"{jump}-AOE"] = new MechanicProperties
	{
		collisionShape = CollisionShape.Round,
		collisionShapeParams = new Vector4(ScaleToSim(5), 360),
		colorHtml = "#ff0060",
		mechanic = new ExecuteMultipleEvents
		{
			events = new List<MechanicEvent>
			{
				new SpawnTargetedEvents { referenceMechanicName = $"Tower-{jump}", isPositionRelative = true, isRotationRelative = true, spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
				new WaitEvent { timeToWait = 0.2f },
				new ApplyEffectToPlayers {
					condition = new CheckPlayerIsMechanicTarget(),
					effects = new List<MechanicEffect>
					{
						new DamageEffect { damageAmount = 40000, damageType = "Physical", name = "Dive" },
						new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						new ApplyStatusEffect { referenceStatusName = "PhysVuln", overrideDuration = 3 }
					},
					failedConditionEffects = new List<MechanicEffect>
					{
						new DamageEffect { damageAmount = 40000, damageType = "Physical", name = "Dive" },
						new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						new ApplyStatusEffect { referenceStatusName = "PhysVuln", overrideDuration = 3 },
						new KnockbackEffect { knockbackDistance = 10},
					}
				},
			}
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
			duration = 8,
		}
	}
};

var lineNames = new string[] { "Zero", "First", "Second", "Third" };

for(int i = 1; i <= 3; i++)
{
	mechanicData.referenceStatusProperties[$"HiJump-{i}"] = new SpawnMechanicOnExpire
	{
		statusIconPath = "Mechanics/Resources/HiJump.png",
		statusName = "Hi Jump Target",
		statusDescription = "Soon to be on the receiving end of a Dark High Jump.",
		duration = i * 10,
		referenceMechanicName = "HiJump-AOE",
	};
	mechanicData.referenceStatusProperties[$"Elusive-{i}"] = new SpawnMechanicOnExpire
	{
		statusIconPath = "Mechanics/Resources/Elusive.png",
		statusName = "Elusive Jump Target",
		statusDescription = "Soon to be on the receiving end of a Dark Elusive Jump.",
		duration = i * 10,
		referenceMechanicName = "Elusive-AOE",
	};
	mechanicData.referenceStatusProperties[$"Spineshatter-{i}"] = new SpawnMechanicOnExpire
	{
		statusIconPath = "Mechanics/Resources/Spineshatter.png",
		statusName = "Spineshatter Dive Target",
		statusDescription = "Soon to be on the receiving end of a Dark Spineshatter Dive.",
		duration = i * 10,
		referenceMechanicName = "Spineshatter-AOE",
	};
	mechanicData.referenceStatusProperties[$"Line-{i}"] = new StatusEffectData
	{
		statusIconPath = $"Mechanics/Resources/Line{i}.png",
		statusName = $"{lineNames[i]} in Line",
		statusDescription = $"Marked as target #{i}.",
		duration = i * 10 + 5,
	};
}

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"InOutPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "InOut", isPositionRelative = true, isRotationRelative = true},
			new SpawnMechanicEvent {referenceMechanicName = "OutIn", isPositionRelative = true, isRotationRelative = true}
		}
	},
	{
		"StackPool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "Stack-Close"},
			new SpawnMechanicEvent {referenceMechanicName = "Stack-Far"}
		}
	},
	{
		"Debuffs1",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "Group1-A"},
			new SpawnMechanicEvent {referenceMechanicName = "Group1-B"}
		}
	},
	{
		"Debuffs2",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "Group2-A"},
			new SpawnMechanicEvent {referenceMechanicName = "Group2-B"}
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" , position = new Vector2(-ScaleToSim(26f), ScaleToSim(26f)), rotation = -45 },
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" , position = new Vector2(ScaleToSim(26f), -ScaleToSim(26f)), rotation = 135 },
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaSquare4x4.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(23f, 23f, 1),
	},
	new SpawnMechanicEvent{	referenceMechanicName = "Spawn-Nidhogg" }
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
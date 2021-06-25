<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "LightRampantDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-mechanics";

JsonConvert.DefaultSettings = () =>
{
	return new JsonSerializerSettings
	{
		NullValueHandling = NullValueHandling.Ignore,
		TypeNameHandling = TypeNameHandling.Auto,
		DefaultValueHandling = DefaultValueHandling.Ignore
	};
};

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"ShivaMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new WaitForAggro(),

					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 1 },

					new StartCastBar { castName = "Junction E7S", duration = 5},
					new WaitEvent { timeToWait = 5 },
					
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/Shiva-Outfit-1.png",
						
						visualDuration = float.PositiveInfinity,
						relativePosition = new Vector3(0.7f, 1.3f, -0.01f),
						scale = Vector3.one * 1.5f,
						isRotationRelative = true,
						colorHtml = "#52ccff",
					},
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/Shiva-Outfit-1.png",
						
						visualDuration = float.PositiveInfinity,
						relativePosition = new Vector3(-0.7f, 1.3f, -0.009f),
						scale = Vector3.one * 1.5f,
						isRotationRelative = true,
						eulerAngles = new Vector3(0, 180, 0),
						colorHtml = "#5e0066",
					},

					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },


					new SetEnemyMovement { position = new Vector2(0, -1), movementTime = -200},
					new WaitEvent { timeToWait = 2 },


					new StartCastBar { castName = "Light Rampant", duration = 5},
					new WaitEvent { timeToWait = 5 },
					new SpawnMechanicEvent { referenceMechanicName = "Raidwide1" },

					new SpawnTethersBetweenPlayers
					{
						targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 1, 2, 3, 4, 5, 6, 7 } },
						tetherIndices = new List<int> {0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 0 },
						referenceTetherName = "LR-Chain",
					},
					new SpawnTargetedEvents
					{
						referenceMechanicName = "ApplyDebuff-L",
						targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0, 2, 4, 6}, dropExtraEvents = true }
					},
					new SpawnTargetedEvents
					{
						referenceMechanicName = "ApplyDebuff-D",
						targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {1, 3, 5, 7}, dropExtraEvents = true }
					},

					new SpawnMechanicEvent { referenceMechanicName = "TowerSet-1" },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "Heavenly Strike", duration = 5},
					new WaitEvent { timeToWait = 5 },
					new SpawnMechanicEvent { referenceMechanicName = "KnockbackFromCenter" },
					new WaitEvent { timeToWait = 4 },
		
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-LargeOrb-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 0},
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-SmallOrb-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 45},
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-LargeOrb-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 90},
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-SmallOrb-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 135},
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-LargeOrb-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 180},
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-SmallOrb-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 225},
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-LargeOrb-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 270},
					new SpawnMechanicEvent {referenceMechanicName = "Spawn-SmallOrb-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 315},

					new WaitEvent { timeToWait = 2 },
					new SpawnMechanicEvent { referenceMechanicName = "TowerSet-2", rotation = 22.5f },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "The Path of Darkness", duration = 5},
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Protean-D", targetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int>{0, 1, 2, 3} } },
					new WaitEvent { timeToWait = 4 },
					new StartCastBar { castName = "The Path of Darkness", duration = 5},
					new WaitEvent { timeToWait = 2 },
					new ExecuteRandomEvents { mechanicPoolName = "TowerSet-3-Pool" },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "Protean-D", targetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int>{0, 1, 2, 3} } },
					new WaitEvent { timeToWait = 9 },
					new ExecuteRandomEvents { mechanicPoolName = "TowerSet-4-Pool" },
					new WaitEvent { timeToWait = 1 },
					new StartCastBar { castName = "The Path of Dark and Light", duration = 5},
					new WaitEvent { timeToWait = 5 },
					new SpawnTargetedEvents { referenceMechanicName = "Protean-D", targetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int>{0, 1, 2, 3} } },
					new SpawnTargetedEvents { referenceMechanicName = "Protean-L", targetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int>{0, 1, 2, 3}, targetNthFarthest = true } },

					new WaitEvent { timeToWait = float.PositiveInfinity },
				}
			}
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
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Inescapable Illumination" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" }
						}
					}
				}
			}
		}
	},
	{
		"Lightsteeped Fail",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(50, 360),
			colorHtml = "#FFFF00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 800000, damageType = "Damage", name = "Lightsteeped" },
					}
				}
			}
		}
	},
	{
		"Tower-1-Offset-L",
		new MechanicProperties {
			visible = false,
			mechanic = new SpawnMechanicEvent {referenceMechanicName = "Tower-1-L", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 6.5f }
		}
	},
	{
		"Tower-1-Offset2-L",
		new MechanicProperties {
			visible = false,
			mechanic = new SpawnMechanicEvent {referenceMechanicName = "Tower-1-L", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 3 }
		}
	},
	{
		"Tower-1-Offset-D",
		new MechanicProperties {
			visible = false,
			mechanic = new SpawnMechanicEvent {referenceMechanicName = "Tower-1-D", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 6.5f }
		}
	},
	{
		"Tower-1-Offset2-D",
		new MechanicProperties {
			visible = false,
			mechanic = new SpawnMechanicEvent {referenceMechanicName = "Tower-1-D", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 3 }
		}
	},
	{
		"TowerSet-1",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 0},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset-D", isPositionRelative = true, isRotationRelative = true, rotation = 45},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 90},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset-D", isPositionRelative = true, isRotationRelative = true, rotation = 135},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 180},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset-D", isPositionRelative = true, isRotationRelative = true, rotation = 225},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset-L", isPositionRelative = true, isRotationRelative = true, rotation = 270},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset-D", isPositionRelative = true, isRotationRelative = true, rotation = 315},
				}
			},
		}
	},
	{
		"TowerSet-2",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset2-L", isPositionRelative = true, isRotationRelative = true, rotation = 0},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset2-L", isPositionRelative = true, isRotationRelative = true, rotation = 45},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset2-L", isPositionRelative = true, isRotationRelative = true, rotation = 90},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset2-L", isPositionRelative = true, isRotationRelative = true, rotation = 135},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset2-L", isPositionRelative = true, isRotationRelative = true, rotation = 180},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset2-L", isPositionRelative = true, isRotationRelative = true, rotation = 225},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset2-L", isPositionRelative = true, isRotationRelative = true, rotation = 270},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-1-Offset2-L", isPositionRelative = true, isRotationRelative = true, rotation = 315},
				}
			},
		}
	},
	{
		"TowerSet-3",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent {referenceMechanicName = "Tower-2-D", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 5},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-2-D", isPositionRelative = true, isRotationRelative = true, position = -Vector3.right * 5},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-4-D", isPositionRelative = true, isRotationRelative = true},
				}
			},
		}
	},
	{
		"TowerSet-4",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent {referenceMechanicName = "Tower-4-L", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 2.5f},
					new SpawnMechanicEvent {referenceMechanicName = "Tower-4-D", isPositionRelative = true, isRotationRelative = true, position = -Vector3.right * 2.5f},
				}
			},
		}
	},
	{
		"Aoe-Green",
		new MechanicProperties {
			colorHtml = "#00FF00",
		}
	},
	{
		"Aoe-White",
		new MechanicProperties {
			colorHtml = "#c6e2ff",
		}
	},
	{
		"Aoe-Purple",
		new MechanicProperties {
			colorHtml = "#5e0066",
		}
	},
	{
		"Protean-D",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(20, 60),
			colorHtml = "#5e0066",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							invertStatus = true,
							statusName = "Umbral Effect",
						},
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 40000, damageType = "Magic", name = "The Path of Darkness" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new ApplyStatusEffect { referenceStatusName = "DarkDebuff" },
							new RemoveStatusEffect { referenceStatusName = "LightDebuff" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "The Path of Darkness" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" },
							new ApplyStatusEffect { referenceStatusName = "DarkDebuff" },
							new KnockbackEffect { knockbackDistance = 4},
						}
					}
				}
			}
		}
	},
	{
		"Protean-L",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(20, 60),
			colorHtml = "#c6e2ff",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							invertStatus = true,
							statusName = "Astral Effect",
						},
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 40000, damageType = "Magic", name = "The Path of Light" },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
							new ApplyStatusEffect { referenceStatusName = "LightDebuff" },
							new RemoveStatusEffect { referenceStatusName = "DarkDebuff" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "The Path of Light" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" },
							new ApplyStatusEffect { referenceStatusName = "LightDebuff" },
							new KnockbackEffect { knockbackDistance = 4},
						}
					}
				}
			}
		}
	},
	{
		"Spawn-SmallOrb-Offset-L",
		new MechanicProperties {
			visible = false,
			mechanic = new SpawnMechanicEvent {referenceMechanicName = "Spawn-SmallOrb-L", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 8 }
		}
	},
	{
		"Spawn-LargeOrb-Offset-L",
		new MechanicProperties {
			visible = false,
			mechanic = new SpawnMechanicEvent {referenceMechanicName = "Spawn-LargeOrb-L", isPositionRelative = true, isRotationRelative = true, position = Vector3.right * 8 }
		}
	},
	{
		"Spawn-SmallOrb-L",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnTargetedEvents
			{
				referenceMechanicName = "SmallOrb-L",
				isPositionRelative = true,
				isRotationRelative = true,
				targetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int> {0}, targetNthFarthest = true }
			}
		}
	},
	{
		"Spawn-LargeOrb-L",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnTargetedEvents
			{
				referenceMechanicName = "LargeOrb-L",
				isPositionRelative = true,
				isRotationRelative = true,
				targetingScheme = new TargetSpecificProximityPlayers { targetIds = new List<int> {0}, targetNthFarthest = true }
			}
		}
	},
	{
		"OrbFollow",
		new MechanicProperties
		{
			followSpeed = 0.3f
		}
	},
	{
		"SmallOrb-L",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.3f, 360),
			colorHtml = "#c6e2ff",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTethersToPlayers { referenceTetherName = "Orb-Tether", targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 5 },
					new ModifyMechanicEvent { referenceMechanicName = "OrbFollow" },
					new WaitEvent { timeToWait = 17 },
					new SpawnMechanicEvent { referenceMechanicName = "OrbExplode-L", isPositionRelative = true },
				}
			},
			persistentTickInterval = 0.1f,
			persistentActivationDelay = 5,
			persistentMechanic = new CheckNumberOfPlayers
			{
				expressionFormat = "{0} = 0",
				failEvent = new ExecuteMultipleEvents{
					events = new List<MechanicEvent> {
						new SpawnMechanicEvent { referenceMechanicName = "OrbPopped-L", isPositionRelative = true },
						new EndMechanic()
					}
				}
			},
		}
	},
	{
		"LargeOrb-L",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.6f, 360),
			colorHtml = "#c6e2ff",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnTethersToPlayers { referenceTetherName = "Orb-Tether", targetingScheme = new TargetExistingTarget() },
					new WaitEvent { timeToWait = 5 },
					new ModifyMechanicEvent { referenceMechanicName = "OrbFollow" },
					new WaitEvent { timeToWait = 18 },
					new ModifyMechanicEvent { referenceMechanicName = "SmallOrb-L" },
					new WaitEvent { timeToWait = 18 },
					new SpawnMechanicEvent { referenceMechanicName = "OrbExplode-L", isPositionRelative = true },
				}
			},
			persistentTickInterval = 0.1f,
			persistentActivationDelay = 5,
			persistentMechanic = new CheckNumberOfPlayers
			{
				expressionFormat = "{0} = 0",
				failEvent = new CheckMechanicTimer {
					expressionFormat = "{0} >= 23",
					successEvent = new ExecuteMultipleEvents {
						events = new List<MechanicEvent> {
							new SpawnMechanicEvent { referenceMechanicName = "OrbPopped-L", isPositionRelative = true },
							new EndMechanic()
						}
					},
					failEvent = new ExecuteMultipleEvents {
						events = new List<MechanicEvent> {
							new SpawnMechanicEvent { referenceMechanicName = "OrbExplode-L", isPositionRelative = true },
							new EndMechanic()
						}
					}
				}
			},
		}
	},
	{
		"OrbPopped-L",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.5f, 360),
			colorHtml = "#c6e2ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus
						{
							invertStatus = true,
							statusName = "Astral Effect",
						},
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 5000, damageType = "Damage", name = "Bright Pulse" },
							new ApplyStatusEffect { referenceStatusName = "LightDebuff" },
							new RemoveStatusEffect { referenceStatusName = "DarkDebuff" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Bright Pulse" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" },
							new ApplyStatusEffect { referenceStatusName = "LightDebuff" },
							new KnockbackEffect { knockbackDistance = 4},
						}
					}
				}
			}
		}
	},
	{
		"OrbExplode-L",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(50, 360),
			colorHtml = "#c6e2ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 100000, damageType = "Damage", name = "Blinding Pulse" },
							new ApplyStatusEffect { referenceStatusName = "Vuln" }
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
							new DamageEffect { damageAmount = 40000, damageType = "Damage", name = "Heavenly Strike" },
							new KnockbackEffect { knockbackDistance = 4 },
						}
					}
				}
			}
		}
	},
	{
		"ApplyDebuff-L",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "LightDebuff" }
			}
		}
	},
	{
		"ApplyDebuff-D",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "DarkDebuff" }
			}
		}
	},
	{
		"AutoAttack",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new DamageEffect { damageAmount = 40000, damageType = "Damage" }
			}
		}
	},
	{
		"Raidwide1",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 80000, damageType = "Damage", name = "Light Rampant" }
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

for (int i = 1; i <= 4; i++)
{
	mechanicData.referenceMechanicProperties[$"Tower-{i}-L"] = new MechanicProperties
	{
		collisionShape = CollisionShape.Round,
		collisionShapeParams = new Vector4(1, 360),
		colorHtml = "#c6e2ff",
		mechanic = new ExecuteMultipleEvents
		{
			events = new List<MechanicEvent>
			{
				new SpawnVisualObject { textureFilePath = $"Mechanics/Resources/LimitCut-{i}.png", colorHtml = "#c6e2ff", visualDuration = 12, relativePosition = Vector3.up, isBillboard = true },
				new WaitEvent { timeToWait = 12 },
				new CheckNumberOfPlayers
				{
					expressionFormat = $"{{0}} = {i}",
					failEvent = new SpawnMechanicEvent { referenceMechanicName = "Tower Fail", isPositionRelative = true }
				},
				new ApplyEffectToPlayers {
					condition = new CheckPlayerStatus
					{
						invertStatus = true,
						statusName = "Astral Effect",
					},
					effects = new List<MechanicEffect>
					{
						new DamageEffect { damageAmount = 5000, damageType = "Damage", name = "Bright Hunger" },
						new ApplyStatusEffect { referenceStatusName = "LightDebuff" },
						new RemoveStatusEffect { referenceStatusName = "DarkDebuff" }
					},
					failedConditionEffects = new List<MechanicEffect>
					{
						new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Bright Hunger" },
						new ApplyStatusEffect { referenceStatusName = "Vuln" },
						new ApplyStatusEffect { referenceStatusName = "LightDebuff" },
						new KnockbackEffect { knockbackDistance = 4},
					}
				}
			}
		},
		persistentMechanic = new CheckNumberOfPlayers
		{
			expressionFormat = $"{{0}} = {i}",
			successEvent = new ModifyMechanicEvent { referenceMechanicName = "Aoe-Green" },
			failEvent = new ModifyMechanicEvent { referenceMechanicName = "Aoe-White" }
		},
		persistentTickInterval = 0.1f
	};
	mechanicData.referenceMechanicProperties[$"Tower-{i}-D"] = new MechanicProperties
	{
		collisionShape = CollisionShape.Round,
		collisionShapeParams = new Vector4(1, 360),
		colorHtml = "#5e0066",
		mechanic = new ExecuteMultipleEvents
		{
			events = new List<MechanicEvent>
			{
				new SpawnVisualObject { textureFilePath = $"Mechanics/Resources/LimitCut-{i}.png", colorHtml = "#5e0066", visualDuration = 12, relativePosition = Vector3.up, isBillboard = true },
				new WaitEvent { timeToWait = 12 },
				new CheckNumberOfPlayers
				{
					expressionFormat = $"{{0}} = {i}",
					failEvent = new SpawnMechanicEvent { referenceMechanicName = "Tower Fail", isPositionRelative = true }
				},
				new ApplyEffectToPlayers {
					condition = new CheckPlayerStatus
					{
						invertStatus = true,
						statusName = "Umbral Effect",
					},
					effects = new List<MechanicEffect>
					{
						new DamageEffect { damageAmount = 5000, damageType = "Damage", name = "Dark Hunger" },
						new ApplyStatusEffect { referenceStatusName = "DarkDebuff" },
						new RemoveStatusEffect { referenceStatusName = "LightDebuff" }
					},
					failedConditionEffects = new List<MechanicEffect>
					{
						new DamageEffect { damageAmount = 120000, damageType = "Damage", name = "Dark Hunger" },
						new ApplyStatusEffect { referenceStatusName = "Vuln" },
						new ApplyStatusEffect { referenceStatusName = "DarkDebuff" },
						new KnockbackEffect { knockbackDistance = 4},
					}
				}
			}
		},
		persistentMechanic = new CheckNumberOfPlayers
		{
			expressionFormat = $"{{0}} = {i}",
			successEvent = new ModifyMechanicEvent { referenceMechanicName = "Aoe-Green" },
			failEvent = new ModifyMechanicEvent { referenceMechanicName = "Aoe-Purple" }
		},
		persistentTickInterval = 0.1f
	};
}

mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"LR-Chain",
		new TetherProperties
		{
			colorHtml = "#FFFF0055",
			tetherDuration = 50,
			persistentActivationDelay = 9,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = 3,
				maxDistance = 7,
				successEvent = new ModifyTetherProperties { referenceTetherName = "Chain-Active" },
				failEvent = new EndTether { shouldTriggerBreakEvent = true }
			},
			breakMechanic = new ApplyEffectToTetheredPlayers
			{
				effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage", name = "Refulgent Fate" }
			}
		}
	},
	{
		"Chain-Active",
		new TetherProperties
		{
			colorHtml2 = "#FFFF00",
			colorHtml = "#FF6600",
			colorDistanceFunction = "10*{0} - {0}*{0} - 22.75"
		}
	},
	{
		"Orb-Tether",
		new TetherProperties
		{
			colorHtml = "#FFFFFF",
			tetherDuration = float.PositiveInfinity
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
			damageMultiplier = 1.1f,
			maxStacks = 16,
			duration = 45,
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
			duration = 12,
		}
	},
	{
		"Lightsteeped",
		new SpawnMechanicOnReachStacks
		{
			statusIconPath = "Mechanics/Resources/Lightsteeped.png",
			statusName = "Lightsteeped",
			statusDescription = "Overflowing with energy. Upon reaching 5 stacks, you will deal damage to those nearby.",
			maxStacks = 5,
			duration = 15,
			requiredStacks = 5,
			referenceMechanicName = "Lightsteeped Fail"
		}
	},
	{
		"LightDebuff",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/LightDebuff.png",
			statusName = "Astral Effect",
			statusDescription = "Damage taken from light is increased.",
			duration = 15,
		}
	},
	{
		"DarkDebuff",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/DarkDebuff.png",
			statusName = "Umbral Effect",
			statusDescription = "Damage taken from darkness is increased.",
			duration = 15
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
			new WaitEvent { timeToWait = 1 },
			new SpawnEnemy {
				enemyName = "Shiva",
				textureFilePath = "Mechanics/Resources/Shiva.png",
				colorHtml = "#0047b1",
				maxHp = 35000000,
				baseMoveSpeed = 0,
				hitboxSize = 3,
				visualPosition = new Vector3(0, 1.2f, 0),
				visualScale = new Vector3(1, 2, 1) * 1.5f,
				referenceMechanicName = "ShivaMechanics",
				rotation = 180
			}
		}
	}
};
mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"TowerSet-3-Pool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-3", isPositionRelative = true, isRotationRelative = true},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-3", isPositionRelative = true, isRotationRelative = true, rotation = 45},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-3", isPositionRelative = true, isRotationRelative = true, rotation = 90},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-3", isPositionRelative = true, isRotationRelative = true, rotation = 135},
		}
	},
	{
		"TowerSet-4-Pool",
		new List<MechanicEvent>
		{
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-4", isPositionRelative = true, isRotationRelative = true},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-4", isPositionRelative = true, isRotationRelative = true, rotation = 45},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-4", isPositionRelative = true, isRotationRelative = true, rotation = 90},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-4", isPositionRelative = true, isRotationRelative = true, rotation = 135},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-4", isPositionRelative = true, isRotationRelative = true, rotation = 180},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-4", isPositionRelative = true, isRotationRelative = true, rotation = 225},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-4", isPositionRelative = true, isRotationRelative = true, rotation = 270},
			new SpawnMechanicEvent {referenceMechanicName = "TowerSet-4", isPositionRelative = true, isRotationRelative = true, rotation = 315},
		}
	},
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
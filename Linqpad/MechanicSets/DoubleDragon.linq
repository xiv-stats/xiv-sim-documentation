<Query Kind="Statements">
  <Reference>E:\GitHub\xivsim\XivMechanicSimNetworked_Data\Managed\Assembly-CSharp.dll</Reference>
  <Reference>E:\Downloads\xiv\xivsim\XivMechanicSimNetworked_Data\Managed\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "DoubleDragonDemo";
var baseOutputPath = @"E:\Downloads\xiv\xivsim\";
var buildOutputPath = @"E:\Downloads\xiv\xivsim\Build";

var mechanicData = new MechanicData();

Vector2 NidLocation = new Vector2(-7.333333f, 0);
Vector2 HraesLocation = new Vector2(7.333333f, 0);

var fireTargets = new TargetSpecificPlayerIdsByClass
{
	classType = PlayerClassType.Tank,
	invertCheck = true,
	targetIds = new List<int> { 0, 1, 2 }	
};

var iceTargets = new TargetSpecificPlayerIdsByClass
{
	classType = PlayerClassType.Tank,
	invertCheck = true,
	targetIds = new List<int> { 3, 4, 5 }	
};

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
					new SetEnemyMovement { movementTime = float.NegativeInfinity },
					new WaitEvent { timeToWait = 4 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new StartCastBar { castName = "Dread Wyrmsbreath", duration = 6.3f },
					new SpawnTethersToPlayers { referenceTetherName = "FireTether",	tetherOffset = new Vector3(0, 2, 0), targetingScheme = fireTargets},
					new SpawnTargetedEvents { referenceMechanicName = "DarkOrbPending", targetingScheme = new TargetNthHighestAggro() },
					new ExecuteRandomEvents { mechanicPoolName = "NidMouthPool" },
					new WaitEvent { timeToWait = 6.8f },
					new SpawnTargetedEvents { referenceMechanicName = "FireProtean", targetingScheme = fireTargets, position = NidLocation },
					new WaitEvent { timeToWait = 0.2f },
					//new SetEnemyTexture { filePath = "Mechanics/Resources/Nidhogg.png" },
					new ReshufflePlayerIds { },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 5.1f },
					new SpawnTargetedEvents { referenceMechanicName = "ApplyMortalVow", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Dps, targetIds = new List<int> { 0 } }, spawnOnTarget = true },
					new WaitEvent { timeToWait = 2.2f },
					new StartCastBar { castName = "Akh Afah", duration = 8 },
					new WaitEvent { timeToWait = 7.8f },
					new SpawnTargetedEvents { referenceMechanicName = "AkhAfah", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Healer, targetIds = new List<int> { 0 } }, spawnOnTarget = true },
					new WaitEvent { timeToWait = 4.4f },
					new ReshufflePlayerIds { },
					new SpawnMechanicEvent { referenceMechanicName = "NidDiveSequence1" },
					new WaitEvent { timeToWait = 10.2f },
					new SpawnMechanicEvent { referenceMechanicName = "NidDive", isPositionRelative = true, isRotationRelative = true },
					new WaitEvent { timeToWait = 5.3f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.2f },
					new StartCastBar { castName = "Wroth Flames", duration = 2.5f },
					new WaitEvent { timeToWait = 2.5f },
					new SpawnTargetedEvents {referenceMechanicName = "ApplySpreading", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{0}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "ApplySpreading", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{1}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "ApplySpreading", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{2}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "ApplySpreading", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{3}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "ApplyEntangled", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{4}, targetLivingOnly = false}},
					new SpawnTargetedEvents {referenceMechanicName = "ApplyEntangled", targetingScheme = new TargetSpecificPlayerIds {targetIds = new List<int>{5}, targetLivingOnly = false}},
					new WaitEvent { timeToWait = 1f },
					new ExecuteRandomEvents { mechanicPoolName = "CrossOrbsPool" },
					new WaitEvent { timeToWait = 2.3f },
					new ReshufflePlayerIds { },
					new StartCastBar { castName = "Akh Morn", duration = 8 },
					new WaitEvent { timeToWait = 7.8f },
					new SpawnTargetedEvents {referenceMechanicName = "AkhMorn", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} }, spawnOnTarget = true },
					new WaitEvent { timeToWait = 1.55f },
					new SpawnTargetedEvents {referenceMechanicName = "AkhMorn", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} }, spawnOnTarget = true },
					new WaitEvent { timeToWait = 1.55f },
					new SpawnTargetedEvents {referenceMechanicName = "AkhMorn", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} }, spawnOnTarget = true },
					new WaitEvent { timeToWait = 1.55f },
					new SpawnTargetedEvents {referenceMechanicName = "AkhMorn", targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> {0} }, spawnOnTarget = true },
					new WaitEvent { timeToWait = 1.65f },
					new ExecuteRandomEvents { mechanicPoolName = "NidWingPool" },
					new ReshufflePlayerIds { },
					new WaitEvent { timeToWait = 9.5f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.15f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2.8f },
					new StartCastBar { castName = "Akh Afah", duration = 8 },
					new WaitEvent { timeToWait = 7.8f },
					new SpawnTargetedEvents { referenceMechanicName = "AkhAfah", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Healer, targetIds = new List<int> { 0 } }, spawnOnTarget = true },
					new WaitEvent { timeToWait = 5.7f },
					new ReshufflePlayerIds { },
					new ExecuteRandomEvents { mechanicPoolName = "NidWingPool" },
					new WaitEvent { timeToWait = 11.6f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2.1f },
					new StartCastBar { castName = "Dread Wyrmsbreath", duration = 6.3f },
					new SpawnTethersToPlayers { referenceTetherName = "FireTether",	tetherOffset = new Vector3(0, 2, 0), targetingScheme = fireTargets},
					new SpawnTargetedEvents { referenceMechanicName = "DarkOrbPending", targetingScheme = new TargetNthHighestAggro() },
					new ExecuteRandomEvents { mechanicPoolName = "NidMouthPool" },
					new WaitEvent { timeToWait = 6.8f },
					new SpawnTargetedEvents { referenceMechanicName = "FireProtean", targetingScheme = fireTargets, position = NidLocation },
					new WaitEvent { timeToWait = 0.2f },
					//new SetEnemyTexture { filePath = "Mechanics/Resources/Nidhogg.png" },
					new WaitEvent { timeToWait = 3f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2f },
					new SpawnMechanicEvent { referenceMechanicName = "NidDiveSequence2" },
					new WaitEvent { timeToWait = 7.5f },
					new SpawnMechanicEvent { referenceMechanicName = "NidDive", isPositionRelative = true, isRotationRelative = true },
					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"HraesvelgrMechanics",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyMovement { movementTime = float.NegativeInfinity },
					new WaitEvent { timeToWait = 4 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new StartCastBar { castName = "Great Wyrmsbreath", duration = 6.3f },
					new SpawnTethersToPlayers { referenceTetherName = "IceTether",	tetherOffset = new Vector3(0, 2, 0), targetingScheme = iceTargets},
					new SpawnTargetedEvents { referenceMechanicName = "LightOrbPending", targetingScheme = new TargetNthHighestAggro() },
					new ExecuteRandomEvents { mechanicPoolName = "HraesMouthPool" },
					new SpawnMechanicEvent { referenceMechanicName = "HraesDonut" },
					new WaitEvent { timeToWait = 6.8f },
					new SpawnTargetedEvents { referenceMechanicName = "IceProtean", targetingScheme = iceTargets, position = HraesLocation },
					new WaitEvent { timeToWait = 0.2f },
					//new SetEnemyTexture { filePath = "Mechanics/Resources/Hraesvelgr.png" },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 4.3f },
					new StartCastBar { castName = "Akh Afah", duration = 8 },
					new WaitEvent { timeToWait = 7.8f },
					new SpawnTargetedEvents { referenceMechanicName = "AkhAfah", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Healer, targetIds = new List<int> { 1 } }, spawnOnTarget = true },
					new WaitEvent { timeToWait = 6.8f },
					new ExecuteRandomEvents { mechanicPoolName = "HraesWingPool" },
					new WaitEvent { timeToWait = 0.5f },
					new StartCastBar { castName = "Hallowed Wings", duration = 7.5f },
					new WaitEvent { timeToWait = 12.9f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3 },
					new SpawnMechanicEvent { referenceMechanicName = "HraesDiveSequence1" },
					new WaitEvent { timeToWait = 10.2f },
					new SpawnMechanicEvent { referenceMechanicName = "HraesDive", isPositionRelative = true, isRotationRelative = true },
					new WaitEvent { timeToWait = 6.5f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new StartCastBar { castName = "Akh Afah", duration = 8 },
					new WaitEvent { timeToWait = 7.8f },
					new SpawnTargetedEvents { referenceMechanicName = "AkhAfah", targetingScheme = new TargetSpecificPlayerIdsByClass { classType = PlayerClassType.Healer, targetIds = new List<int> { 1 } }, spawnOnTarget = true },
					new WaitEvent { timeToWait = 4.7f },
					new StartCastBar { castName = "Hallowed Wings", duration = 7.5f },
					new ExecuteRandomEvents { mechanicPoolName = "HraesWingPool" },
					new WaitEvent { timeToWait = 12.6f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 3.1f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2.1f },
					new StartCastBar { castName = "Great Wyrmsbreath", duration = 6.3f },
					new SpawnMechanicEvent { referenceMechanicName = "HraesDonut" },
					new SpawnTethersToPlayers { referenceTetherName = "IceTether",	tetherOffset = new Vector3(0, 2, 0), targetingScheme = iceTargets},
					new SpawnTargetedEvents { referenceMechanicName = "LightOrbPending", targetingScheme = new TargetNthHighestAggro() },
					new ExecuteRandomEvents { mechanicPoolName = "HraesMouthPool" },
					new WaitEvent { timeToWait = 6.8f },
					new SpawnTargetedEvents { referenceMechanicName = "IceProtean", targetingScheme = iceTargets, position = HraesLocation },
					new WaitEvent { timeToWait = 0.2f },
					//new SetEnemyTexture { filePath = "Mechanics/Resources/Hraesvelgr.png" },
					new WaitEvent { timeToWait = 3f },
					new SpawnTargetedEvents { referenceMechanicName = "AutoAttack", targetingScheme = new TargetNthHighestAggro() },
					new WaitEvent { timeToWait = 2f },
					new SpawnMechanicEvent { referenceMechanicName = "HraesDiveSequence2" },
					new WaitEvent { timeToWait = 7.5f },
					new SpawnMechanicEvent { referenceMechanicName = "HraesDive", isPositionRelative = true, isRotationRelative = true },
					new WaitEvent { timeToWait = float.PositiveInfinity }
				}
			}
		}
	},
	{
		"HallowedWings",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(16, 7.333f),
			colorHtml = "#80ffff",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Hallowed Wings" },
						},
					},
				}
			}
		}
	},
	{
		"HallowedPlume",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(3.333f, 360),
			colorHtml = "#00ffff",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 190000, damageType = "Damage", name = "Hallowed Plume" },
						},
					}
				}
			}
		}
	},
	{
		"IceProtean",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(30, 13),
			colorHtml = "#00ffff",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Boiling" },
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 50000, damageType = "Ice", name = "Ice Breath" },
							new ApplyStatusEffect { referenceStatusName = "IceVuln" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 50000, damageType = "Ice", name = "Ice Breath" },
							new ApplyStatusEffect { referenceStatusName = "IceVuln" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" },
							new ApplyStatusEffect { referenceStatusName = "Freezing" }
						},
					},
					new WaitEvent { timeToWait = 0.01f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Boiling" },
						effects = new List<MechanicEffect>
						{
							new RemoveStatusEffect { referenceStatusName = "Boiling", doExpireEvent = false },
						},
					}
				}
			}
		}
	},
	{
		"FireProtean",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(30, 13),
			colorHtml = "#ff0000",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Freezing" },
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 50000, damageType = "Fire", name = "Fire Breath" },
							new ApplyStatusEffect { referenceStatusName = "FireVuln" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 50000, damageType = "Fire", name = "Fire Breath" },
							new ApplyStatusEffect { referenceStatusName = "FireVuln" },
							new ApplyStatusEffect { referenceStatusName = "PhysVuln" },
							new ApplyStatusEffect { referenceStatusName = "Boiling" }
						}
					},
					new WaitEvent { timeToWait = 0.01f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Freezing" },
						effects = new List<MechanicEffect>
						{
							new RemoveStatusEffect { referenceStatusName = "Freezing", doExpireEvent = false },
						},
					}
				}
			}
		}
	},
	{
		"LightBreathPending",
		new MechanicProperties
		{
			mechanicTag = "Breath",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 6.8f },
					new SpawnMechanicEvent
					{
						referenceMechanicName = "LightBreath",
						position = HraesLocation,
						rotation = 270
					},
				}
			}
		}
	},
	{
		"DarkBreathPending",
		new MechanicProperties
		{
			mechanicTag = "Breath",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 6.8f },
					new SpawnMechanicEvent
					{
						referenceMechanicName = "DarkBreath",
						position = NidLocation,
						rotation = 90
					},
				}
			}
		}
	},
	{
		"LightBreath",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(30, 30),
			colorHtml = "#c6e2ff",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 999999, damageType = "TrueDamage", name = "Light Breath" },
						},
					}
				}
			}
		}
	},
	{
		"DarkBreath",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(30, 30),
			colorHtml = "#8e3096",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 999999, damageType = "TrueDamage", name = "Dark Breath" },
						},
					}
				}
			}
		}
	},
	{
		"NidMouthClosed",
		new MechanicProperties
		{
			mechanicTag = "Mouth",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					//new SetEnemyTexture { filePath = "Mechanics/Resources/Nidhogg.png" },
					new SpawnMechanicEvent { referenceMechanicName = "CheckBothClosedNid" },
					new WaitEvent { timeToWait = 0.1f },
					new ClearMechanicsWithTag { mechanicTag = "Orb" },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "SoloBusterPending",
						targetingScheme = new TargetNthHighestAggro()
					},
				}
			}
		}
	},
	{
		"NidMouthOpen",
		new MechanicProperties
		{
			mechanicTag = "Mouth",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					//new SetEnemyTexture { filePath = "Mechanics/Resources/NidhoggMouthOpen.png" },
					new SpawnMechanicEvent { referenceMechanicName = "DarkBreathPending" },
					new WaitEvent { timeToWait = 0.01f },
					new ClearMechanicsWithTag { mechanicTag = "Check" },
					new SpawnVisualObject 
					{ 
						textureFilePath = "Mechanics/Resources/NidhoggMouthOpen.png", 
						colorHtml = "#111111", 
						visualDuration = 7f, 
						relativePosition = new Vector3(-7.3f, 2, 0), 
						scale = new Vector3(1, 1, 1) * 6f, 
						eulerAngles = new Vector3(0, 90, 0)
					},
				}
			}
		}
	},
	{
		"HraesMouthClosed",
		new MechanicProperties
		{
			mechanicTag = "Mouth",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					//new SetEnemyTexture { filePath = "Mechanics/Resources/Hraesvelgr.png" },
					new SpawnMechanicEvent { referenceMechanicName = "CheckBothClosedHraes" },
					new WaitEvent { timeToWait = 0.1f },
					new ClearMechanicsWithTag { mechanicTag = "Orb" },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "SoloBusterPending",
						targetingScheme = new TargetNthHighestAggro()
					},
				}
			}
		}
	},
	{
		"HraesMouthOpen",
		new MechanicProperties
		{
			mechanicTag = "Mouth",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					//new SetEnemyTexture { filePath = "Mechanics/Resources/HraesvelgrMouthOpen.png" },
					new SpawnMechanicEvent { referenceMechanicName = "LightBreathPending" },
					new WaitEvent { timeToWait = 0.01f },
					new ClearMechanicsWithTag { mechanicTag = "Check" },
					new SpawnVisualObject 
					{ 
						textureFilePath = "Mechanics/Resources/HraesvelgrMouthOpen.png", 
						colorHtml = "#0047b1", 
						visualDuration = 7f, 
						relativePosition = new Vector3(7.3f, 2, 0), 
						scale = new Vector3(1, 1, 1) * 6f, 
						eulerAngles = new Vector3(0, 270, 0)
					},
				}
			}
		}
	},
	{
		"CheckBothClosedNid",
		new MechanicProperties
		{
			mechanicTag = "Check",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.05f },
					new ClearMechanicsWithTag { mechanicTag = "Mouth" },
					new ClearMechanicsWithTag { mechanicTag = "Breath" },
					new WaitEvent { timeToWait = 0.01f },
					new SpawnMechanicEvent { referenceMechanicName = "NidMouthOpen" },
				}
			}
		}
	},
	{
		"CheckBothClosedHraes",
		new MechanicProperties
		{
			mechanicTag = "Check",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.05f },
					new ClearMechanicsWithTag { mechanicTag = "Mouth" },
					new ClearMechanicsWithTag { mechanicTag = "Breath" },
					new WaitEvent { timeToWait = 0.01f },
					new SpawnMechanicEvent { referenceMechanicName = "HraesMouthOpen" },
				}
			}
		}
	},
	{
		"DarkOrbPending",
		new MechanicProperties
		{
			mechanicTag = "Orb",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1f },
					new ClearMechanicsWithTag { mechanicTag = "Solo" },
					new ClearMechanicsWithTag { mechanicTag = "Breath" },
					new WaitEvent { timeToWait = 5.8f },
					new SpawnTargetedEvents { referenceMechanicName = "DarkOrb", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
				}
			}
		}
	},
	{
		"LightOrbPending",
		new MechanicProperties
		{
			mechanicTag = "Orb",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1f },
					new ClearMechanicsWithTag { mechanicTag = "Solo" },
					new ClearMechanicsWithTag { mechanicTag = "Breath" },
					new WaitEvent { timeToWait = 5.8f },
					new SpawnTargetedEvents { referenceMechanicName = "LightOrb", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
				}
			}
		}
	},
	{
		"DarkOrb",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 360),
			colorHtml = "#5e0066",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Sustained Light Damage" },
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 70000, damageType = "Magic", name = "Dark Orb" },
							new RemoveStatusEffect { referenceStatusName = "LightDot", doExpireEvent = false },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 70000, damageType = "Magic", name = "Dark Orb" },
							new ApplyStatusEffect { referenceStatusName = "DarkDot" }
						}
					}
				}
			}
		}
	},
	{
		"LightOrb",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 360),
			colorHtml = "#c6e2ff",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Sustained Dark Damage" },
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 70000, damageType = "Magic", name = "Light Orb" },
							new RemoveStatusEffect { referenceStatusName = "DarkDot", doExpireEvent = false },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 70000, damageType = "Magic", name = "Light Orb" },
							new ApplyStatusEffect { referenceStatusName = "LightDot" }
						}
					}
				}
			}
		}
	},
	{
		"SoloBusterPending",
		new MechanicProperties
		{
			mechanicTag = "Solo",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 6.8f },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "SoloBuster", spawnOnTarget = true, targetingScheme = new TargetExistingTarget()
					},
				}
			}
		}
	},
	{
		"SoloBuster",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(5, 360),
			colorHtml = "#aaaaaa",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 200000, damageType = "Magic", name = "Staggering Breath" },
						},
					}
				}
			}
		}
	},
	{
		"HraesDiveSequence1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyVisible { visible = false },
					new SetEnemyTargetability { isTargetable = false },
					new WaitEvent { timeToWait = 0.5f },
					new ExecuteRandomEvents { mechanicPoolName = "HraesDivePool" },
					new WaitEvent { timeToWait = 0.7f },
					new SetEnemyVisible { visible = true },
					new SetEnemyTargetability { isTargetable = true },
					new WaitEvent { timeToWait = 4.2f },
					new StartCastBar { castName = "Cauterize", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SetEnemyVisible { visible = false },
					new SetEnemyTargetability { isTargetable = false },
					new WaitEvent { timeToWait = 0.5f },
					new SetEnemyMovement { position = HraesLocation, movementTime = 0.1f },
					new WaitEvent { timeToWait = 0.1f },
					new SetEnemyMovement { position = Vector2.zero, movementTime = -1 },
					new SetEnemyMovement { movementTime = float.NegativeInfinity },
					new WaitEvent { timeToWait = 4.5f },
					new SetEnemyVisible { visible = true },
					new SetEnemyTargetability { isTargetable = true },
				}
			}
		}
	},
	{
		"HraesDiveSequence2",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyVisible { visible = false },
					new SetEnemyTargetability { isTargetable = false },
					new WaitEvent { timeToWait = 0.5f },
					new SetEnemyMovement { position = new Vector2(3.666f, 7.333f), movementTime = 0.1f },
					new WaitEvent { timeToWait = 0.1f },
					new SetEnemyMovement { position = new Vector2(3.666f, 0), movementTime = float.NegativeInfinity },
					new WaitEvent { timeToWait = 0.6f },
					new SetEnemyVisible { visible = true },
					new SetEnemyTargetability { isTargetable = true },
					new WaitEvent { timeToWait = 1.3f },
					new StartCastBar { castName = "Cauterize", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SetEnemyVisible { visible = false },
					new SetEnemyTargetability { isTargetable = false },
					new WaitEvent { timeToWait = 0.5f },
					new SetEnemyMovement { position = new Vector2(0, -7.333f), movementTime = 0.1f },
					new WaitEvent { timeToWait = 0.1f },
					new SetEnemyMovement { position = Vector2.zero, movementTime = float.NegativeInfinity },
					new WaitEvent { timeToWait = 6.4f },
					new SetEnemyVisible { visible = true },
					new SetEnemyTargetability { isTargetable = true },
					new SpawnMechanicEvent { referenceMechanicName = "Touchdown" },
					new WaitEvent { timeToWait = 1.5f },
					new StartCastBar { castName = "Revenge of the Horde", duration = 25 },
					new WaitEvent { timeToWait = 25f },
					new SpawnMechanicEvent { referenceMechanicName = "Enrage" },
				}
			}
		}
	},
	{
		"NidDiveSequence1",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyVisible { visible = false },
					new SetEnemyTargetability { isTargetable = false },
					new WaitEvent { timeToWait = 0.5f },
					new ExecuteRandomEvents { mechanicPoolName = "NidDivePool" },
					new WaitEvent { timeToWait = 0.7f },
					new SetEnemyVisible { visible = true },
					new SetEnemyTargetability { isTargetable = true },
					new WaitEvent { timeToWait = 4.2f },
					new StartCastBar { castName = "Cauterize", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SetEnemyVisible { visible = false },
					new SetEnemyTargetability { isTargetable = false },
					new WaitEvent { timeToWait = 0.5f },
					new SetEnemyMovement { position = NidLocation, movementTime = 0.1f },
					new WaitEvent { timeToWait = 0.1f },
					new SetEnemyMovement { position = Vector2.zero, movementTime = -1 },
					new SetEnemyMovement { movementTime = float.NegativeInfinity },
					new WaitEvent { timeToWait = 2.4f },
					new SetEnemyVisible { visible = true },
					new SetEnemyTargetability { isTargetable = true },
				}
			}
		}
	},
	{
		"NidDiveSequence2",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyVisible { visible = false },
					new SetEnemyTargetability { isTargetable = false },
					new WaitEvent { timeToWait = 0.5f },
					new SetEnemyMovement { position = new Vector2(-3.666f, 7.333f), movementTime = 0.1f },
					new WaitEvent { timeToWait = 0.1f },
					new SetEnemyMovement { position = new Vector2(-3.666f, 0), movementTime = float.NegativeInfinity },
					new WaitEvent { timeToWait = 0.6f },
					new SetEnemyVisible { visible = true },
					new SetEnemyTargetability { isTargetable = true },
					new WaitEvent { timeToWait = 1.3f },
					new StartCastBar { castName = "Cauterize", duration = 5 },
					new WaitEvent { timeToWait = 5 },
					new SetEnemyVisible { visible = false },
					new SetEnemyTargetability { isTargetable = false },
					new WaitEvent { timeToWait = 0.5f },
					new SetEnemyMovement { position = Vector2.zero, movementTime = 0.1f },
					new WaitEvent { timeToWait = 0.1f },
					new SetEnemyMovement { position = new Vector2(0, -7), movementTime = float.NegativeInfinity },
					new WaitEvent { timeToWait = 6.4f },
					new SetEnemyVisible { visible = true },
					new SetEnemyTargetability { isTargetable = true },
					new SpawnMechanicEvent { referenceMechanicName = "Touchdown" },
					new WaitEvent { timeToWait = 1.5f },
					new StartCastBar { castName = "Revenge of the Horde", duration = 25 },
					new WaitEvent { timeToWait = 25f },
					new SpawnMechanicEvent { referenceMechanicName = "Enrage" },
				}
			}
		}
	},
	{
		"NidDive",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(16, 7.333f),
			colorHtml = "#8e3096",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Deep Freeze" },
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 40000, damageType = "Damage", name = "Cauterize" },
							new RemoveStatusEffect { referenceStatusName = "Frozen", doExpireEvent = false },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 200000, damageType = "Damage", name = "Cauterize" },
							new ApplyStatusEffect { referenceStatusName = "Burns" }
						}
					}
				}
			}
		}
	},
	{
		"HraesDive",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(16, 7.333f),
			colorHtml = "#c6e2ff",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Pyretic" },
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 40000, damageType = "Damage", name = "Cauterize" },
							new RemoveStatusEffect { referenceStatusName = "Pyretic", doExpireEvent = false },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 200000, damageType = "Damage", name = "Cauterize" },
							new ApplyStatusEffect { referenceStatusName = "Frostbite" }
						}
					}
				}
			}
		}
	},
	{
		"MortalVowTarget",
		new MechanicProperties
		{
			visible = false,
			mechanic = new SpawnTargetedEvents { referenceMechanicName = "SpreadMortalVow", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
		}
	},
	{
		"ApplyMortalVow",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.666f, 360),
			colorHtml = "#808000",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.1f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 20000, damageType = "MortalVow", name = "Mortal Vow" },
							new ApplyStatusEffect { referenceStatusName = "MortalVow" }
						},
					}
				}
			}
		}
	},
	{
		"SpreadMortalVow",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.666f, 360),
			colorHtml = "#808000",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.1f },
					new ApplyEffectToPlayers {
						condition = new CheckMultipleConditions 
						{
							requireAll = true,
							conditions = new List<Condition>
							{
								new CheckPlayerStatus { statusName = "Mortal Atonement" },
								new CheckPlayerIsMechanicTarget { invertStatus = true },
							}
						},
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 999999, damageType = "TrueDamage", name = "Nidhogg enraged :(" }
						},
					},
					new ApplyEffectToPlayers {
						condition = new CheckPlayerIsMechanicTarget(),
						effects = new List<MechanicEffect>
						{
							new ApplyStatusEffect { referenceStatusName = "MortalAtonement" }
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 20000, damageType = "MortalVow", name = "Mortal Vow" },
						}
					},
					new ApplyEffectToPlayers {
						condition = new CheckPlayerStatus { statusName = "Mortal Atonement", invertStatus = true },
						effects = new List<MechanicEffect>
						{
							new ApplyStatusEffect { referenceStatusName = "MortalVow" }
						},
					},
					new CheckNumberOfPlayers
					{
						expressionFormat = "{0} > 1",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "NidEnrage" },
					},
				}
			}
		}
	},
	{
		"CheckNidEnrage",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(50, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers 
			{
				condition = new CheckPlayerStatus { statusNames = new List<String> { "Mortal Atonement", "Mortal Vow" } },
				effect = new DamageEffect { damageAmount = 999999, damageType = "TrueDamage", name = "Nidhogg enraged :(" }
			}
		}
	},
	{
		"NidEnrage",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 999999, damageType = "TrueDamage", name = "Nidhogg enraged :(" }
			}
		}
	},
	{
		"Enrage",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ApplyEffectToPlayers
			{
				effect = new DamageEffect { damageAmount = 999999, damageType = "TrueDamage", name = "Revenge of the Horde" }
			}
		}
	},
	{
		"HraesDonut",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(13, 360, 6.67f),
			colorHtml = "#ff9600",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 7f },
					new ModifyMechanicEvent { referenceMechanicName = "ChangeColor" },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 999999, damageType = "TrueDamage", name = "Swirling Blizzard" },
						},
					}
				}
			}
		}
	},
	{
		"AkhAfah",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.333f, 360),
			colorHtml = "#ff4200",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers { 
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 360000, damageType = "Magic", name = "Akh Afah (pretend boss health is equal)", maxStackAmount = 8 },
							new ApplyStatusEffect { referenceStatusName = "MagicVuln" },
						}
					},
				}
			}
		}
	},
	{
		"AkhMorn",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.333f, 360),
			colorHtml = "#ff2000",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers { 
						effect = new DamageEffect { damageAmount = 360000, damageType = "Magic", name = "Akh Morn", maxStackAmount = 8 },
					},
					new SpawnTargetedEvents { referenceMechanicName = "AkhMornPuddle", spawnOnTarget = true, targetingScheme = new TargetExistingTarget() },
				}
			}
		}
	},
	{
		"AkhMornPuddle",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.666f, 360),
			colorHtml = "#ff2000",
			mechanic = new WaitEvent { timeToWait = 14 },
			persistentTickInterval = 0.3f,
			persistentActivationDelay = 2,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 300000, damageType = "Damage", name = "Poop" } },
		}
	},
	{
		"SpawnCrossOrbs",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent { referenceMechanicName = "CrossOrbs", isPositionRelative = true, isRotationRelative = true, position = new Vector2(0, 0) },
					new WaitEvent { timeToWait = 2f },
					new SpawnMechanicEvent { referenceMechanicName = "CrossOrbs", isPositionRelative = true, isRotationRelative = true, position = new Vector2(4.5f, -4.5f) },
					new WaitEvent { timeToWait = 3f },
					new SpawnMechanicEvent { referenceMechanicName = "CrossOrbs", isPositionRelative = true, isRotationRelative = true, position = new Vector2(-4.5f, 4.5f) },
				}
			}
		}
	},
	{
		"CrossOrbs",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject 
					{ 
						textureFilePath = "Mechanics/Resources/NidOrbs.png", 
						colorHtml = "#ff4200", 
						visualDuration = 12.5f, 
						relativePosition = Vector3.up, 
						scale = new Vector3(1, 1, 1) * 2f, 
						eulerAngles = new Vector3(0, 180, 0), 
						isBillboard = true 
					},
					new WaitEvent { timeToWait = 11f },
					new SpawnMechanicEvent { referenceMechanicName = "CrossOrbsSnapshot", isPositionRelative = true, position = new Vector2(0, -14), rotation = 0 },
					new SpawnMechanicEvent { referenceMechanicName = "CrossOrbsSnapshot", isPositionRelative = true, position = new Vector2(-14, 0), rotation = 90 },
				}
			}
		}
	},
	{
		"CrossOrbsSnapshot",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(28, 6.43f),
			colorHtml = "#ff9600",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1.5f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 200000, damageType = "Damage", name = "Flame Blast" },
						}
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
					new StartCastBar { castName = "Hot Wing", duration = 6.5f },
					new WaitEvent { timeToWait = 6.3f },
					new SpawnMechanicEvent { referenceMechanicName = "HotWingSnapshot", position = new Vector2(-7.333f, -4.6f), rotation = 90 },
					new SpawnMechanicEvent { referenceMechanicName = "HotWingSnapshot", position = new Vector2(-7.333f, 4.6f), rotation = 90 },
				}
			}
		}
	},
	{
		"HotWingSnapshot",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(16, 6.4f),
			colorHtml = "#ff9600",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Hot Wing" },
						}
					}
				}
			}
		}
	},
	{
		"HotTail",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new StartCastBar { castName = "Hot Tail", duration = 6.5f },
					new WaitEvent { timeToWait = 6.3f },
					new SpawnMechanicEvent { referenceMechanicName = "HotTailSnapshot", position = new Vector2(-7.333f, 0), rotation = 90 },
				}
			}
		}
	},
	{
		"HotTailSnapshot",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(16, 5.133f),
			colorHtml = "#ff9600",
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 999999, damageType = "Damage", name = "Hot Tail" },
						}
					}
				}
			}
		}
	},
	{
		"EntangledFlamesSnapshot",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.333f, 360),
			colorHtml = "#ff8000",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 100000, damageType = "Fire", name = "Entangled Flames", maxStackAmount = 2 },
							new ApplyStatusEffect { referenceStatusName = "FireVuln" }
						}
					},
					new CheckNumberOfPlayers
					{
						expressionFormat = "{0} = 2",
						failEvent = new ApplyEffectToPlayers {
							effects = new List<MechanicEffect> {
								new DamageEffect { damageAmount = 999999, damageType = "Fire", name = "Entangled Pyre" },
							}
						}
					},
				}
			}
		}
	},
	{
		"SpreadingFlamesSnapshot",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.666f, 360),
			colorHtml = "#ff8000",
			visible = true,
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						condition = new CheckPlayerIsMechanicTarget(),
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 50000, damageType = "Fire", name = "Spreading Flames" },
						},
						failedConditionEffects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 999999, damageType = "Fire", name = "Entangled Pyre" },
							new KnockbackEffect { knockbackDistance = 10},
						}
					}
				}
			}
		}
	},
	{
		"Touchdown",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(100, 360),
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							//new ProximityDamageEffect { maxDamageAmount = 100000, minDamageAmount = 30000, maxDistance = 15, damageType = "Physical", name = "Touchdown" },
							new DamageEffect { damageAmount = 50000, damageType = "Physical", name = "Touchdown" },
						},
					}
				}
			}
		}
	},
	{
		"ApplyFreeze",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "Frozen" }
			}
		}
	},
	{
		"ApplyBoil",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "Pyretic" }
			}
		}
	},
	{
		"ApplySpreading",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "SpreadingFlames" },
			}
		}
	},
	{
		"ApplyEntangled",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly
			{
				effect = new ApplyStatusEffect { referenceStatusName = "EntangledFlames" },
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
				effect = new DamageEffect { damageAmount = 40000, damageType = "Physical", name = "Wyrmclaw" }
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
		"ChangeColor",
		new MechanicProperties
		{
			colorHtml = "#80ffff"
		}
	},
	{
		"ArenaBoundary",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(30, 270),
			colorHtml = "#8800ff",

			persistentTickInterval = 0.2f,
			persistentMechanic = new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage" } },
		}
	}
};
mechanicData.referenceTetherProperties = new Dictionary<string, TetherProperties>
{
	{
		"FireTether",
		new TetherProperties
		{
			colorHtml = "#ff00ff",
			colorHtml2 = "#ff2000",
			tetherDuration = 7f,
			persistentActivationDelay = 6.9f,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = 8,
				failEvent = new EndTether { shouldTriggerBreakEvent = true }
			},
			breakMechanic = new ApplyEffectToTetheredPlayers
			{
				effect = new ApplyStatusEffect { referenceStatusName = "FireVuln" }
			},
			colorDistanceFunction = "100000*{0} - 800000"
		}
	},
	{
		"IceTether",
		new TetherProperties
		{
			colorHtml = "#ff00ff",
			colorHtml2 = "#00ffff",
			tetherDuration = 7f,
			persistentActivationDelay = 6.9f,
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckTetherLength
			{
				minDistance = 8,
				failEvent = new EndTether { shouldTriggerBreakEvent = true }
			},
			breakMechanic = new ApplyEffectToTetheredPlayers
			{
				effect = new ApplyStatusEffect { referenceStatusName = "IceVuln" }
			},
			colorDistanceFunction = "100000*{0} - 800000"
		}
	},
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"IceVuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/IceVuln.png",
			statusName = "Ice Resistance Down II",
			statusDescription = "Ice resistance is significantly reduced.",
			duration = 3,
			damageType = "Ice",
			damageMultiplier = 10,
		}
	},
	{
		"FireVuln",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/FireVuln.png",
			statusName = "Fire Resistance Down II",
			statusDescription = "Fire resistance is significantly reduced.",
			duration = 3,
			damageType = "Fire",
			damageMultiplier = 10,
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
			duration = 10,
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
			duration = 3,
		}
	},
	{
		"MortalVow",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/MortalVow.png",
			statusName = "Mortal Vow",
			statusDescription = "Condemned by Nidhogg's vow to avenge his brood-sister.",
			duration = 34f,
			shouldKeepOnDeath = true,
			referenceMechanicName = "SpreadMortalVow",
		}
	},
	{
		"MortalAtonement",
		new DamageModifier
		{
			statusIconPath = "Mechanics/Resources/MortalAtonement.png",
			statusName = "Mortal Atonement",
			statusDescription = "No longer condemned by Nidhogg's Mortal Vow.",
			duration = 100,
			damageType = "MortalVow",
			shouldKeepOnDeath = true,
			damageMultiplier = 100,
		}
	},
	{
		"EntangledFlames",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/EntangledFlames.png",
			statusName = "Entangled Flames",
			statusDescription = "Caught in Hraesvelgr's entangled flames.",
			duration = 25f,
			referenceMechanicName = "EntangledFlamesSnapshot",
		}
	},
	{
		"SpreadingFlames",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/SpreadingFlames.png",
			statusName = "Spreading Flames",
			statusDescription = "Caught in Nidhogg's spreading flames.",
			duration = 25f,
			referenceMechanicName = "SpreadingFlamesSnapshot",
		}
	},
	{
		"Freezing",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/Freezing.png",
			statusName = "Freezing",
			statusDescription = "Body is slowly turning to ice. Will experience a Deep Freeze when this effect expires.",
			duration = 11,
			referenceMechanicName = "ApplyFreeze",
		}
	},
	{
		"Boiling",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/Boiling.png",
			statusName = "Boiling",
			statusDescription = "Body is slowly heating up. Will become Pyretic when this effect expires.",
			duration = 11,
			referenceMechanicName = "ApplyBoil",
		}
	},
	{
		"Frozen",
		new SpeedModifier
		{
			statusIconPath = "Mechanics/Resources/Frozen.png",
			statusName = "Deep Freeze",
			statusDescription = "Frozen solid and unable to execute actions.",
			duration = 30,
			disableType = DisableType.Actions | DisableType.Knockback | DisableType.Movement
		}
	},
	{
		"Pyretic",
		new SpeedModifier
		{
			statusIconPath = "Mechanics/Resources/Pyretic.png",
			statusName = "Pyretic",
			statusDescription = "Fire-aspected damage is taken with every action.",
			duration = 30,
			disableType = DisableType.Actions | DisableType.Knockback | DisableType.Movement
		}
	},
	{
		"Burns",
		new DamageOverTime
		{
			statusIconPath = "Mechanics/Resources/Burns.png",
			statusName = "Burns",
			statusDescription = "Sustaining fire damage over time.",
			duration = 27,
			tickInterval = 3,
			damageAmount = 30000,
		}
	},
	{
		"Frostbite",
		new DamageOverTime
		{
			statusIconPath = "Mechanics/Resources/Frostbite.png",
			statusName = "Frostbite",
			statusDescription = "Sustaining ice damage over time.",
			duration = 27,
			tickInterval = 3,
			damageAmount = 30000,
		}
	},
	{
		"LightDot",
		new DamageOverTime
		{
			statusIconPath = "Mechanics/Resources/LightDot.png",
			statusName = "Sustained Light Damage",
			statusDescription = "Light is causing damage over time.",
			duration = 30,
			tickInterval = 3,
			damageAmount = 100000,
		}
	},
	{
		"DarkDot",
		new DamageOverTime
		{
			statusIconPath = "Mechanics/Resources/DarkDot.png",
			statusName = "Sustained Dark Damage",
			statusDescription = "Darkness is causing damage over time.",
			duration = 30,
			tickInterval = 3,
			damageAmount = 100000,
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" , position = new Vector2(-7.333f, 7.333f), rotation = -45 },
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" , position = new Vector2(7.333f, -7.333f), rotation = 135 },
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaSquare4x4.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(23f, 23f, 1),
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>
		{
			new WaitEvent { timeToWait = 1 },
			new SpawnEnemy {
				enemyName = "Nidhogg",
				textureFilePath = "Mechanics/Resources/Nidhogg.png",
				colorHtml = "#111111",
				maxHp = 35000000,
				baseMoveSpeed = 0,
				hitboxSize = 17.6f,
				position = new Vector3(-7.333f, 0, 0),
				visualPosition = new Vector3(0, 2f, 0),
				visualScale = new Vector3(1, 1, 1) * 6f,
				referenceMechanicName = "NidhoggMechanics",
				rotation = 90
			},
			new SpawnEnemy {
				enemyName = "Hraesvelgr",
				textureFilePath = "Mechanics/Resources/Hraesvelgr.png",
				colorHtml = "#0047b1",
				maxHp = 35000000,
				baseMoveSpeed = 0,
				hitboxSize = 17.6f,
				position = new Vector3(7.333f, 0, 0),
				visualPosition = new Vector3(0, 2f, 0),
				visualScale = new Vector3(1, 1, 1) * 6f,
				referenceMechanicName = "HraesvelgrMechanics",
				rotation = 270
			}
		}
	}
};

mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>();
mechanicData.mechanicPools["NidDivePool"] = new List<MechanicEvent>();
mechanicData.mechanicPools["NidMouthPool"] = new List<MechanicEvent>();
mechanicData.mechanicPools["NidWingPool"] = new List<MechanicEvent>();
mechanicData.mechanicPools["HraesDivePool"] = new List<MechanicEvent>();
mechanicData.mechanicPools["HraesMouthPool"] = new List<MechanicEvent>();
mechanicData.mechanicPools["HraesWingPool"] = new List<MechanicEvent>();
mechanicData.mechanicPools["CrossOrbsPool"] = new List<MechanicEvent>();

mechanicData.mechanicPools["NidMouthPool"].Add(new SpawnMechanicEvent { referenceMechanicName = "NidMouthOpen" });
mechanicData.mechanicPools["NidMouthPool"].Add(new SpawnMechanicEvent { referenceMechanicName = "NidMouthClosed" });
mechanicData.mechanicPools["HraesMouthPool"].Add(new SpawnMechanicEvent { referenceMechanicName = "HraesMouthOpen" });
mechanicData.mechanicPools["HraesMouthPool"].Add(new SpawnMechanicEvent { referenceMechanicName = "HraesMouthClosed" });
mechanicData.mechanicPools["NidWingPool"].Add(new SpawnMechanicEvent { referenceMechanicName = "HotWing" });
mechanicData.mechanicPools["NidWingPool"].Add(new SpawnMechanicEvent { referenceMechanicName = "HotTail" });

foreach (var i in new List<float> {7.333f, -7.333f})
{
	foreach (var j in new List<float> {3.666f, -3.666f})
	{
		mechanicData.mechanicPools["NidDivePool"].Add(new ExecuteMultipleEvents
		{
			events = new List<MechanicEvent>
			{
				new SetEnemyMovement
				{
					position = new Vector2(j, i),
					movementTime = 0.1f
				},
				new WaitEvent { timeToWait = 0.1f },
				new SetEnemyMovement
				{
					position = new Vector2(j, -i),
					movementTime = float.NegativeInfinity
				},
				new WaitEvent { timeToWait = 0.5f },
			}
		});
	}
}

foreach (var i in new List<string> {"Up", "Down"})
{
	foreach (var j in new List<string> {"Left", "Right"})
	{
		string path = "Mechanics/Resources/Hraesvelgr" + i + j + ".png";
		float sideOffset = j == "Left" ? 3.666f : -3.666f;
		var scheme = i == "Down" ? new TargetSpecificProximityPlayers { targetIds = new List<int>{0, 1} } : new TargetSpecificProximityPlayers { targetIds = new List<int>{0, 1}, targetNthFarthest = true };
		mechanicData.mechanicPools["HraesWingPool"].Add(new ExecuteMultipleEvents
		{
			events = new List<MechanicEvent>
			{
				//new SetEnemyTexture { filePath = path },
				new SpawnVisualObject 
					{ 
						textureFilePath = path, 
						colorHtml = "#0047b1", 
						visualDuration = 8.1f, 
						relativePosition = new Vector3(0, 2, 0.033f), 
						scale = new Vector3(1, 1, 1) * 6f,  
						eulerAngles = new Vector3(0, 90, 0)
					},
				new WaitEvent { timeToWait = 7.3f },
				new SpawnMechanicEvent
				{
					referenceMechanicName = "HallowedWings",
					position = new Vector2(7.333f, sideOffset),
					rotation = 270
				},
				new WaitEvent { timeToWait = 0.4f },
				new SpawnTargetedEvents
				{
					referenceMechanicName = "HallowedPlume",
					targetingScheme = scheme,
					spawnOnTarget = true
				},
				new WaitEvent { timeToWait = 0.4f },
				//new SetEnemyTexture { filePath = "Mechanics/Resources/Hraesvelgr.png" },
			}
		});
	}
}

foreach (var i in new List<float> {3.666f, 0, -3.666f})
{
	mechanicData.mechanicPools["HraesDivePool"].Add(new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>
		{
			new SetEnemyMovement
			{
				position = new Vector2(i, -7.333f),
				movementTime = 0.1f
			},
			new WaitEvent { timeToWait = 0.1f },
			new SetEnemyMovement
			{
				position = new Vector2(i, 0),
				movementTime = float.NegativeInfinity
			},
		}
	});
}

foreach (var i in new List<float> {0, 90, 180, 270})
{
	mechanicData.mechanicPools["CrossOrbsPool"].Add(new SpawnMechanicEvent
	{
		referenceMechanicName = "SpawnCrossOrbs",
		isRotationRelative = true,
		rotation = i,
		position = Vector2.zero
	});
}

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
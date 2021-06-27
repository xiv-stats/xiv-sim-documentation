<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "AwayWithTheeDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-documentation";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"DrawIn",
		new MechanicProperties
		{
			visible = true,
			collisionShapeParams = new Vector4(0.3f, 360),
			colorHtml = "#d800ff99",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1 },
					new ApplyEffectToTargetOnly {
						effects = new List<MechanicEffect>
						{
							new KnockbackEffect { knockbackDistance = 1, isDrawIn = true, additionalKnockbackSpeed = 5 },
						}
					},
				}
			}
		}
	},
	{
		"DrawInLeft",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = "Stun" } },
					new SpawnTargetedEvents { referenceMechanicName = "DrawIn", isPositionRelative = true, isRotationRelative = true, spawnOnTarget = true, position = new Vector2(-3, 0), targetingScheme = new TargetExistingTarget() }
				}
			},
		}
	},
	{
		"LeftWithThee",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent> {
					new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = "LeftWithThee" } },
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/Mark1.png",
						colorHtml = "#d800ff",
						visualDuration = 5,
						spawnOnPlayer = true,
						relativePosition = new Vector3(-3, 0.6f, 0),
						scale = new Vector3(0.8f, 0.8f, 1),
						isBillboard = true
					},
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/LimitCut-1.png",
						colorHtml = "#d800ff99",
						visualDuration = 5,
						spawnOnPlayer = true,
						relativePosition = new Vector3(-3, 0.1f, 0),
						eulerAngles = new Vector3(90, 0, 0),
					},
				}
			}
		}
	}
};


mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"LeftWithThee",
		new SpawnMechanicOnExpire
		{
			statusIconPath = "Mechanics/Resources/LeftWithThee.png",
			statusName = "Larboard With Thee",
			statusDescription = "When this effect ends, you will be spawned and forcibly moved leftwards.",
			duration = 5,
			referenceMechanicName = "DrawInLeft"
		}
	},
	{
		"Stun",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/Stun.png",
			statusName = "Stun",
			statusDescription = "When this effect ends, you will be spawned and forcibly moved leftwards.",
			duration = 3f,
			disableType = DisableType.Movement | DisableType.Actions
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaSquare4x4.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(15.8637f, 15.8637f, 1),
	},
	new SpawnTargetedEvents { referenceMechanicName = "LeftWithThee", targetingScheme = new TargetAllPlayers() },
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
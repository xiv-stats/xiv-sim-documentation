<Query Kind="Statements">
  <Reference>D:\src\Unity\xiv-sim\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "TargetedAoeDemo";
var baseOutputPath = @"D:\src\Unity\xiv-sim";
var buildOutputPath = @"D:\src\Unity\xiv-sim-documentation";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"TargetedCircle",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#ff9600",
			isTargeted = true,
			followSpeed = 10000,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 15 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Circle Aoe" }
					},
				}
			},
		}
	},
	{
		"AimedRectangle",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(50, 1),
			colorHtml = "#0196ff",
			isTargeted = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 15 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Rectangle Aoe" }
					},
				}
			},
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnTargetedEvents { referenceMechanicName = "TargetedCircle", targetingScheme = new TargetAllPlayers() },
	new SpawnTargetedEvents { referenceMechanicName = "AimedRectangle", targetingScheme = new TargetAllPlayers() }
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
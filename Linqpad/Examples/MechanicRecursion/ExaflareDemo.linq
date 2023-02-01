<Query Kind="Statements">
  <Reference>D:\src\Unity\xiv-sim\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "ExaflareDemo";
var baseOutputPath = @"D:\src\Unity\xiv-sim";
var buildOutputPath = @"D:\src\Unity\xiv-sim-documentation";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"Exaflare",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 2 },
					new CheckMechanicDepth {
						expressionFormat = "{0} < 5",
						successEvent = new SpawnMechanicEvent { referenceMechanicName = "Exaflare", isPositionRelative = true, isRotationRelative = true, position = new Vector2(0, 1.5f) }
					},
					new WaitEvent { timeToWait = 1 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Exaflare" }
					}
				}
			}
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "Exaflare", position = new Vector3(0, 3) },
	new SpawnMechanicEvent { referenceMechanicName = "Exaflare", position = new Vector3(3, 0), rotation = 90 },
	new SpawnMechanicEvent { referenceMechanicName = "Exaflare", position = new Vector3(0, -3), rotation = 180 },
	new SpawnMechanicEvent { referenceMechanicName = "Exaflare", position = new Vector3(-3, 0), rotation = 270 },
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
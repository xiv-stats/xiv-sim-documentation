<Query Kind="Statements">
  <Reference>D:\src\Unity\xiv-sim\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "InnocenceAoeDemo";
var baseOutputPath = @"D:\src\Unity\xiv-sim";
var buildOutputPath = @"D:\src\Unity\xiv-sim-documentation";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"Donut Cone",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(5, 120, 3),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Innocence Aoe" }
					}
				}
			}
		}
	},
	{
		"Donut Cone Offset",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnMechanicEvent
					{
						referenceMechanicName = "Donut Cone",
						isPositionRelative = true,
						isRotationRelative = true,
						position = new Vector3(4, 0),
						rotation = -30
					},
					new WaitEvent { timeToWait = 2 },
					new SpawnMechanicEvent { referenceMechanicName = "Donut Cone Offset", isPositionRelative = true, isRotationRelative = true, rotation = -25 }
				}
			}
		}
	}
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "Donut Cone Offset", position = new Vector2(0, 0) },
	new SpawnMechanicEvent { referenceMechanicName = "Donut Cone Offset", position = new Vector2(0, 0), rotation = 180 },
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
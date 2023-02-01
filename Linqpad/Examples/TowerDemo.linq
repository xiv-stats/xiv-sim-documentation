<Query Kind="Statements">
  <Reference>D:\src\Unity\xiv-sim\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "TowerDemo";
var baseOutputPath = @"D:\src\Unity\xiv-sim";
var buildOutputPath = @"D:\src\Unity\xiv-sim-documentation";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"Aoe-Green",
		new MechanicProperties
		{
			colorHtml = "#00ff00",
		}
	},
	{
		"Tower",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 5 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Tower" }
					},
					new CheckNumberOfPlayers {
						expressionFormat = "{0} = 1",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "TowerFailed", isPositionRelative = true }
					},
				}
			},
			persistentTickInterval = 0.1f,
			persistentMechanic = new CheckNumberOfPlayers {
				expressionFormat = "{0} = 1",
				successEvent = new ModifyMechanicEvent { referenceMechanicName = "Aoe-Green" },
				failEvent = new ModifyMechanicEvent { referenceMechanicName = "Tower" }
			},
		}
	},
	{
		"TowerFailed",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(3, 360),
			colorHtml = "#ff0000",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 9999999, damageType = "TrueDamage", name = "TowerFailed" }
					}
				}
			}
		}
	}
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "Tower" },
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
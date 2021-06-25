<Query Kind="Statements">
  <Reference>D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "SimpleAoeDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-documentation";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"Circle",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Circle Aoe" }
					}
				}
			}
		}
	},
	{
		"Cone",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 120),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Cone Aoe" }
					}
				}
			}
		}
	},
	{
		"Donut",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 360, 1),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Donut Aoe" }
					}
				}
			}
		}
	},
	{
		"Donut Cone",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(2, 120, 1),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Donut Cone Aoe" }
					}
				}
			}
		}
	},
	{
		"Rectangle",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(10, 1),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Rectangle Aoe" }
					}
				}
			}
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "Circle" },
	new SpawnMechanicEvent { referenceMechanicName = "Cone", position = new Vector2(2, 0) },
	new SpawnMechanicEvent { referenceMechanicName = "Donut", position = new Vector2(6, 0) },
	new SpawnMechanicEvent { referenceMechanicName = "Donut Cone", position = new Vector2(10, 0) },
	new SpawnMechanicEvent { referenceMechanicName = "Rectangle", position = new Vector2(0, 4), rotation = 90 },
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
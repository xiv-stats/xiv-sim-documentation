<Query Kind="Statements">
  <Reference Relative="..\..\..\..\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll">D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "KnockbackDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-documentation";

var mechanicData = new MechanicData();

mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	{
		"Knockback",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(3, 360),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Knockback" },
							new KnockbackEffect { knockbackDistance = 3, canArmsLength = true },
						}
					}
				}
			}
		}
	},
	{
		"DrawIn",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(3, 360),
			colorHtml = "#0078ff",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 3 },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect>
						{
							new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Draw In" },
							new KnockbackEffect { knockbackDistance = 1, isDrawIn = true, additionalKnockbackSpeed = 5 },
						}
					}
				}
			}
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "Knockback", position = new Vector2(-2, 0) },
	new SpawnMechanicEvent { referenceMechanicName = "DrawIn", position = new Vector2(2, 0) }
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
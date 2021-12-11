<Query Kind="Statements">
  <Reference Relative="..\..\..\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll">D:\src\Unity\XivMechanicSimNetworked\Library\ScriptAssemblies\Assembly-CSharp.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Unity\Hub\Editor\2020.3.6f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var mechanicName = "RotationDemo";
var baseOutputPath = @"D:\src\Unity\XivMechanicSimNetworked";
var buildOutputPath = @"D:\src\Unity\xiv-sim-documentation";


var planetVisual = new SpawnVisualObject
{
	textureFilePath = "Mechanics/Resources/Cat.png",
	visualDuration = 6,
	colorHtml = "#b429bd",
	isBillboard = true,
	relativePosition = new Vector3(0, 1.5f, 0),
	scale = new Vector3(2, 2, 2),
};

var platformRotateVisuals = new List<MechanicEvent>();

for (int i = 0; i < 50; i++)
{
	var angle = 360f/ 50 * i;
	var rads = angle * Mathf.Deg2Rad;
	
	platformRotateVisuals.Add(new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/Arrow.png",
		visualDuration = 5,
		colorHtml = "#2579bd",
		relativePosition = new Vector3(Mathf.Cos(rads), 0, Mathf.Sin(rads)) * 8 + Vector3.up,
		eulerAngles = new Vector3(0, 90 - angle , 0),
		scale = new Vector3(1, 1, 1),
	});
}

var mechanicData = new MechanicData();
mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
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
	{
		"Explosion",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(12, 360),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.5f },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 30000, damageType = "Damage", name = "CAT-Astrophe" }
					}
				}
			}
		}
	},
	{
		"SnakeAOE",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Rectangle,
			collisionShapeParams = new Vector4(14, 3.5f),
			colorHtml = "#ff9600",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 1 },
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 30000, damageType = "Damage", name = "Snake" }
					}
				}
			}
		}
	},
	{
		"SpawnPlanets",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnEnemy {
						enemyName = "Doomed Stars",
						textureFilePath = "Mechanics/Resources/Cat.png",
						maxHp = 35000000,
						hitboxSize = 1,
						referenceMechanicName = "SlowPlanet",
						visualScale = Vector3.zero,
						isTargetable = false,
						showInEnemyList = false,
					},
					new SpawnEnemy {
						enemyName = "Doomed Stars",
						textureFilePath = "Mechanics/Resources/Cat.png",
						maxHp = 35000000,
						hitboxSize = 1,
						referenceMechanicName = "FastPlanet",
						visualScale = Vector3.zero,
						isTargetable = false,
						showInEnemyList = false,
					},
					new WaitEvent { timeToWait = 5.5f },
					new SpawnMechanicEvent { referenceMechanicName = "Explosion", position = new Vector2(7, 0) },
				}
			}
		}
	},
	{
		"SpawnSnakes",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnEnemy {
						enemyName = "Snake",
						textureFilePath = "Mechanics/Resources/Snake.png",
						maxHp = 35000000,
						hitboxSize = 1,
						referenceMechanicName = "Snake",
						visualScale = Vector3.zero,
						isTargetable = true,
						showInEnemyList = false,
						position = new Vector2(0f, 0.01f),
						rotation = 90
					}
				}
			}
		}
	},
	{
		"Snake",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/Snake.png",
						visualDuration = 7.5f,
						colorHtml = "#2529bd",
						relativePosition = new Vector3(5.25f, 1, -1.75f),
						eulerAngles = new Vector3(0, 180, 0),
						isRotationRelative = true,
						scale = new Vector3(2, 2, 2),
					},
					new SpawnVisualObject
					{
						textureFilePath = "Mechanics/Resources/Snake.png",
						visualDuration = 7.5f,
						colorHtml = "#2529bd",
						relativePosition = new Vector3(5.25f, 1, 5.25f),
						eulerAngles = new Vector3(0, 180, 0),
						isRotationRelative = true,
						scale = new Vector3(2, 2, 2),
					},
					new WaitEvent { timeToWait = 4 },
					new SetEnemyMovementPath { path = new CircleMovementPath { radius = 0.01f, degreesPerSecond = -30, startAngle = 90} },
					new WaitEvent { timeToWait = 3.05f },
					new SpawnMechanicEvent { referenceMechanicName = "SnakeAOE", position = new Vector2(7, -1.75f), rotation = -90, isPositionRelative = true, isRotationRelative = true },
					new SpawnMechanicEvent { referenceMechanicName = "SnakeAOE", position = new Vector2(7, 5.25f), rotation = -90, isPositionRelative = true, isRotationRelative = true },
				}
			}
		}
	},
	{
		"SlowPlanet",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyMovementPath { path = new CircleMovementPath { radius = 7.5f, degreesPerSecond = 0, startAngle = -90} },
					planetVisual,
					new WaitEvent { timeToWait = 1 },
					new SetEnemyMovementPath { path = new CircleMovementPath { radius = 7.5f, degreesPerSecond = 18, startAngle = -90} },
					new WaitEvent { timeToWait = 5 },
				}
			}
		}
	},
	{
		"FastPlanet",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SetEnemyMovementPath { path = new CircleMovementPath { radius = 7.5f, degreesPerSecond = 0, startAngle = 180} },
					planetVisual,
					new WaitEvent { timeToWait = 1 },
					new SetEnemyMovementPath { path = new CircleMovementPath { radius = 7.5f, degreesPerSecond = 36, startAngle = 180} },
					new WaitEvent { timeToWait = 5 },
				}
			}
		}
	},
	{
		"StunPlayers",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = "Stun" } }
		}
	}
};

mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"Stun",
		new StatusEffectData
		{
			statusIconPath = "Mechanics/Resources/Stun.png",
			statusName = "Bind",
			statusDescription = "Unable to move.",
			duration = 5f,
			disableType = DisableType.Movement
		}
	},
};

mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" },
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaSquare4x4.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(18f, 18, 1),
	},
	new ExecuteMultipleEvents
	{
		events = new List<MechanicEvent>
		{
			new SpawnMechanicEvent { referenceMechanicName = "SpawnPlanets" },
			new SpawnMechanicEvent { referenceMechanicName = "SpawnSnakes" },
			
			new WaitEvent { timeToWait = 2 },
			new ExecuteMultipleEventsParallel { events = platformRotateVisuals },
			
			new WaitEvent { timeToWait = 2 },
			new SpawnTargetedEvents { referenceMechanicName = "StunPlayers", targetingScheme = new TargetAllPlayers() },
		}
	}
};

var resultText = mechanicData.ToString();

File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{baseOutputPath}\Build\Mechanics\{mechanicName}.json", resultText);
File.WriteAllText($@"{buildOutputPath}\Mechanics\{mechanicName}.json", resultText);

$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
<Query Kind="Statements">
  <Reference Relative="..\xiv-sim_Data\Managed\Assembly-CSharp.dll">C:\Users\exces\Desktop\XIV SIM\xiv-sim_Data\Managed\Assembly-CSharp.dll</Reference>
  <Reference Relative="..\xiv-sim_Data\Managed\UnityEngine.CoreModule.dll">C:\Users\exces\Desktop\XIV SIM\xiv-sim_Data\Managed\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

var buildOutputPath = @"C:\Users\exces\Desktop\XIV SIM\Mechanic Builds";

var mechanicName = "GrandOctetDemo";
var mechanicData = new MechanicData();

//Re-usable constants
const int DIVE_WIDTH = 7;
const float BOSS_DISTANCE = 7.5f;

//Starting Parameters
mechanicData.mechanicEvents = new List<MechanicEvent>
{
	new SpawnVisualObject
	{
		textureFilePath = "Mechanics/Resources/ArenaCircle.png",
		visualDuration = float.PositiveInfinity,
		relativePosition = new Vector3(0, -0.001f, 0),
		eulerAngles = new Vector3(90, 0, 0),
		scale = new Vector3(15.8637f, 15.8637f, 1),
	},
	new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary" },
	new WaitEvent { timeToWait = 1 },
	
	new SpawnEnemy {
		enemyName = "Bahamut",
		textureFilePath = "Mechanics/Resources/Bahamut.png",
		colorHtml = "#0a4d8b",
		maxHp = 10000000,
		baseMoveSpeed = 0,
		hitboxSize = 3,
		visualPosition = new Vector3(0, 1.2f, 0),
		visualScale = new Vector3(1, 1.5f, 1) * 1.5f,
		referenceMechanicName = "BahamutStart",
		rotation = 180
	}
};


mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
{
	//Modifiers
	{
		"Snapshot",
		new MechanicProperties
		{
			isTargeted = false,
			followSpeed = 0,
		}
	},
	{
		"SetVisible",
		new MechanicProperties
		{
			visible = true
		}
	},
	//Mechanics
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
		"BahamutStart",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents {
				events = new List<MechanicEvent> {
					new WaitForAggro(),
					new ExecuteRandomEvents { mechanicPoolName = "RotationPool" },
					new SpawnMechanicEvent { referenceMechanicName = "MechanicsPart2" },
					
					new SetEnemyMovement { movementTime = -100, moveToTarget = new TargetNthHighestAggro() },
					new StartCastBar { castName = "Grand Octet", duration = 4},
					new WaitEvent { timeToWait = 6.5f },
					new EndMechanic()
				}
			}
		}
	},
	{
		"SpawnBosses",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ExecuteRandomEvents { mechanicPoolName = "OrderPool" },
					new WaitEvent { timeToWait = 0.5f }
				}
			}
		}
	},
	{
		"MechanicsPart2",
		new MechanicProperties {
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 35.9f },
					new ExecuteRandomEvents { mechanicPoolName = "TowerPool", numberToSpawn = 4},
					new WaitEvent { timeToWait = 1 },
					new SpawnTargetedEvents { referenceMechanicName = "MegaflareTarget", targetingScheme = new TargetRandomPlayers { totalTargetsNeeded = 4 } },
					new WaitEvent { timeToWait = 4.6f },
					new SpawnTargetedEvents
					{
						referenceMechanicName = "MegaflareStack",
						targetingScheme = new TargetRandomPlayers
						{
							numTargets = 0,                                    	                       // Get all players in a random order
							targetCondition = new CheckPlayerStatus { statusName = "MegaflareMark" },  // Filter to only players marked by megaflare
							totalTargetsNeeded = 1,                                                    // Select one of the players to place the stack on
						},
						spawnOnTarget = true
					},
					new WaitEvent { timeToWait = 2f },
					new SpawnTargetedEvents { referenceMechanicName = "Twister", spawnOnTarget = true, targetingScheme = new TargetRandomPlayers { totalTargetsNeeded = 4 } },
				}
			}
		}
	},
	{
		"Tower",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1, 360),
			colorHtml = "#FFFF00",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Tower.png", colorHtml = "#FFFF00", visualDuration = 7.8f,
											relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1) * 0.6f, eulerAngles = new Vector3(0, 0, 0) },
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Tower.png", colorHtml = "#FFFF00", visualDuration = 7.8f,
											relativePosition = Vector3.up, scale = new Vector3(1, 1.9f, 1) * 0.6f, eulerAngles = new Vector3(0, 90, 0) },
					new WaitEvent { timeToWait = 7.8f },
					new CheckNumberOfPlayers
					{
						expressionFormat = "{0} >= 1",
						failEvent = new SpawnMechanicEvent { referenceMechanicName = "Tower Fail", isPositionRelative = true }
					},
					new ApplyEffectToPlayers {
						effect = new DamageEffect { damageAmount = 10000, damageType = "Damage", name = "Megaflare" }
					}
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
						effect = new DamageEffect { damageAmount = 200000, damageType = "Damage", name = "Tower Failed" }
					}
				}
			}
		}
	},
	{
		"MegaflareTarget",
		new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new SpawnVisualObject { textureFilePath = "Mechanics/Resources/Mark1.png", colorHtml = "#ff4200", visualDuration = 4,
											spawnOnPlayer = true, relativePosition = Vector3.up * 0.8f, scale = new Vector3(0.5f, 0.5f, 1), isBillboard = true },
					new ApplyEffectToTargetOnly { effect = new ApplyStatusEffect { referenceStatusName = "MegaflareMark" } }
				}
			},
		}
	},
	{
		"MegaflareStack",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(1.68f, 360),
			colorHtml = "#ff4200",
			isTargeted = true,
			followSpeed = 10000,
			visible = true,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ApplyEffectToPlayers { effect = new DamageEffect { damageAmount = 350000, damageType = "Damage", name = "Megaflare", maxStackAmount = 4 } }
				}
			}
		}
	},
	{
		"Twister",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(0.25f, 360),
			colorHtml = "#008542",
			visible = false,
			isTargeted = true,
			followSpeed = 100,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new ModifyMechanicEvent { referenceMechanicName = "Snapshot" },
					new WaitEvent { timeToWait = 0.8f },
					new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
					new WaitEvent { timeToWait = 5 },
				}
			},
			persistentTickInterval = 0.1f,
			persistentActivationDelay = 1.6f,
			persistentMechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new CheckNumberOfPlayers
					{
						expressionFormat = "{0} = 0",
						failEvent = new ExecuteMultipleEvents{
							events = new List<MechanicEvent> {
								new SpawnMechanicEvent { referenceMechanicName = "Twister Explode", isPositionRelative = true },
								new EndMechanic()
							}
						}
					},
				}
			},
		}
	},
	{
		"Twister Explode",
		new MechanicProperties
		{
			collisionShape = CollisionShape.Round,
			collisionShapeParams = new Vector4(3, 360),
			colorHtml = "#008542",
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = 0.2f },
					new ApplyEffectToPlayers {
						effects = new List<MechanicEffect> {
							new DamageEffect { damageAmount = 90000, damageType = "Damage", name = "Twister" },
							new KnockbackEffect { knockbackDistance = 10 },
						}
					}
				}
			}
		}
	},
};

int targetID = 0;
void addDiveMechanic(string boss, string bossColor, string markerColor, string diveColor,
					 float spawnTime, float markerTime, float snapshotTime, float markerDuration,
					 string damageText, bool extraDragons = false)
{
	for (int i = 0; i <= (extraDragons ? 4 : 0); i++)
	{
		mechanicData.referenceMechanicProperties[boss + (extraDragons ? i : "")] = new MechanicProperties
		{
			visible = false,
			mechanic = new ExecuteMultipleEvents
			{
				events = new List<MechanicEvent>
				{
					new WaitEvent { timeToWait = spawnTime },
					new SpawnVisualObject()
					{
						textureFilePath = $"Mechanics/Resources/{boss}.png",
						colorHtml = bossColor,
						//The imprecise floats in JSON were bothering me, so I had to round some of these, sorry
						visualDuration = MathF.Round(snapshotTime - spawnTime + 2*i, 2),
						relativePosition = new Vector3(0, 1, -BOSS_DISTANCE),
						scale = new Vector3(1, 1, 1),
						eulerAngles = new Vector3(0, 180, 0),
						isRotationRelative = true
					},
					new WaitEvent { timeToWait = MathF.Round(markerTime - spawnTime + 2*i, 2) },
					new SpawnTargetedEvents
					{
						referenceMechanicName = $"{boss}Dive",
						position = new Vector2(0, -BOSS_DISTANCE),
						targetingScheme = new TargetSpecificPlayerIds { targetIds = new List<int> { targetID++ } },
						isPositionRelative = true,
						isRotationRelative = true
					}
				}
			}
		};
	}
	
	mechanicData.referenceMechanicProperties[$"{boss}Dive"] = new MechanicProperties
	{
		collisionShape = CollisionShape.Rectangle,
		collisionShapeParams = new Vector4(16, DIVE_WIDTH),
		colorHtml = diveColor,
		visible = false,
		isTargeted = true,
		mechanic = new ExecuteMultipleEvents
		{
			events = new List<MechanicEvent>
			{
				new SpawnVisualObject()
				{
					textureFilePath = "Mechanics/Resources/Mark1.png",
					colorHtml = markerColor,
					visualDuration = markerDuration,
					relativePosition = Vector3.up,
					spawnOnPlayer = true,
					scale = Vector3.one * 0.8f,
					isBillboard = true
				},
				new WaitEvent { timeToWait = MathF.Round(snapshotTime - markerTime, 2) },
				new SpawnVisualObject()
				{
					textureFilePath = $"Mechanics/Resources/{boss}.png",
					colorHtml = bossColor,
					visualDuration = 4,
					relativePosition = new Vector3(0, 1, 0),
					scale = new Vector3(1, 1, 1),
					eulerAngles = new Vector3(0, 180, 0),
					isRotationRelative = true
				},
				new ModifyMechanicEvent { referenceMechanicName = "Snapshot" },
				new WaitEvent { timeToWait = 4 },
				new ModifyMechanicEvent { referenceMechanicName = "SetVisible" },
				new ApplyEffectToPlayers {
					effects = new List<MechanicEffect> {
						new DamageEffect { damageAmount = 90000, damageType = "Damage", name = damageText },
						new KnockbackEffect { knockbackDistance = 10 },
					}
				},
				new WaitEvent { timeToWait = 0.5f }
			}
		}
	};
}

addDiveMechanic(boss: "Nael", bossColor: "#a917bf", markerColor: "#c4c278", diveColor: "#c4c278",
				spawnTime: 8, markerTime: 12.4f, snapshotTime: 12.5f, markerDuration: 3,
				damageText: "Lunar Dive");
				
addDiveMechanic(boss: "Bahamut", bossColor: "#0a4d8b", markerColor: "#f07b22", diveColor: "#b81515",
				spawnTime: 8, markerTime: 29.6f, snapshotTime: 29.7f, markerDuration: 2.8f,
				damageText: "Megaflare Dive");
				
addDiveMechanic(boss: "Twintania", bossColor: "#067743", markerColor: "#32730a", diveColor: "#0a4d8b",
				spawnTime: 8, markerTime: 38.6f, snapshotTime: 38.7f, markerDuration: 3,
				damageText: "Twisting Dive");
				
addDiveMechanic(boss: "Dragon", bossColor: null, markerColor: "#32730a", diveColor: "#7d1876",
				spawnTime: 2.9f, markerTime: 12.5f, snapshotTime: 19.5f, markerDuration: 6.4f,
				damageText: "Cauterize", extraDragons: true);


//Mechanic Pools
mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>>
{
	{
		"RotationPool",
		new List<MechanicEvent>()
		{
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 0},
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 90},
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 180},
			new SpawnMechanicEvent { referenceMechanicName = "SpawnBosses", rotation = 270}
		}
	},
	{ "OrderPool", new List<MechanicEvent>() },
	{ "TowerPool", new List<MechanicEvent>() }
};
foreach (int orientation in new [] { 1, -1 })
{
	//For the sake of a smaller file size, and better practice, I have opted to remove some easier patterns.
	//Otherwise these loops should be from 0 through 5, and from 0 through 6.
	for (int twin = 1; twin <= 5; twin++)
	{
		for (int nael = 2; nael <= 4; nael++)
		{
			var mech = new List<string> { "Dragon0", "Dragon1", "Dragon2", "Dragon3", "Dragon4" };
			mech.Insert(twin, "Twintania");
			mech.Insert(nael, "Nael");
			mech.Insert(0, "Bahamut");
			var spawnEvents = new List<MechanicEvent>();
			for (int i = 0; i < 8; i++)
			{
				float a = ((orientation == 1 ? 1 : 0) + i * orientation) * Mathf.PI / 4;
				//	Postion is now calculated within the boss mechanic to reduce OrderPool size in JSON
				// 	Removes 5 lines * 8 bosses * 2*5*3 order variations = -1200 lines from the JSON file
    			//float x = MathF.Round(BOSS_DISTANCE * Mathf.Cos(3 * Mathf.PI / 2 - a), 3);
    			//float y = MathF.Round(BOSS_DISTANCE * Mathf.Sin(3 * Mathf.PI / 2 - a), 3);
				spawnEvents.Add(
					new SpawnMechanicEvent
					{
						referenceMechanicName = mech[i],
						rotation = MathF.Round(a * Mathf.Rad2Deg),
						//position = new Vector2(x, y),
						//isPositionRelative = true,
						isRotationRelative = true
					}
				);
			}
			mechanicData.mechanicPools["OrderPool"].Add(new ExecuteMultipleEvents { events = spawnEvents });
		}
	}
}
for (int i = 0; i < 8; i++)
{
	float a = i * Mathf.PI / 4;
	float x = MathF.Round(3.5f * Mathf.Cos(a), 3);
	float y = MathF.Round(3.5f * Mathf.Sin(a), 3);
	mechanicData.mechanicPools["TowerPool"].Add(new SpawnMechanicEvent { referenceMechanicName = "Tower", position = new Vector2(x, y) });
}


//Status Effects
mechanicData.referenceStatusProperties = new Dictionary<string, StatusEffectData>
{
	{
		"MegaflareMark",
		new StatusEffectData
		{
			statusName = "Marked for Megaflare",
			statusDescription = "Chosen to share the Megaflare stack.",
			duration = 7,
		}
	}
};


var resultText = mechanicData.ToString();
File.WriteAllText($@"{buildOutputPath}\{mechanicName}.json", resultText);

$"Finished writing json to {mechanicName}.json".Dump();
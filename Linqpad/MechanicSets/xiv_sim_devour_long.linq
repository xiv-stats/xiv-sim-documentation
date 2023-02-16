<Query Kind="Program">
  <Reference Relative="..\..\Programs\XivMechanicSim\XivMechanicSimNetworked_Data\Managed\Assembly-CSharp.dll">C:\Users\jen\Programs\XivMechanicSim\XivMechanicSimNetworked_Data\Managed\Assembly-CSharp.dll</Reference>
  <Reference Relative="..\..\Programs\XivMechanicSim\XivMechanicSimNetworked_Data\Managed\UnityEngine.CoreModule.dll">C:\Users\jen\Programs\XivMechanicSim\XivMechanicSimNetworked_Data\Managed\UnityEngine.CoreModule.dll</Reference>
  <Namespace>UnityEngine</Namespace>
</Query>

// sim distance values are 1/3 game values apparently
public class DevourData {
public readonly record struct Point(float X, float Y);
public static readonly Point[] targetLocationsClockwise = { new Point(2,10f/3), new Point(10f/3,2), new Point(10f/3,-2), new Point(2,-10f/3), new Point(-2,-10f/3), new Point(-10f/3,-2), new Point(-10f/3,2), new Point(-2,10f/3) };
public static float mouthInitialPauseTime = 4.5f;
public static float mouthUsualPauseTime = 0.2f;
public static float mouthTravelTime = 0.95f;
public static float mouthFinalPauseTime = 0.95f;
public static float firstAoEDelay = 2.3f;
public static float firstAoEWaitTime = mouthInitialPauseTime + mouthFinalPauseTime + 6 * mouthUsualPauseTime + 7 * mouthTravelTime + firstAoEDelay;
public static float AoEVisibleTime = 0.5f;
public static float TimeBetweenStampedeHits = 1.2f;
}

List<MechanicEvent> makeTargetMarker(float x, float y, float duration) {
	var events = new List<MechanicEvent> {
		new SpawnVisualObject {
			textureFilePath = "Mechanics/Resources/Mark1Blue.png",
			relativePosition = new Vector3(x, 0.8f, y),
			scale = new Vector3(0.5f, 0.5f, 1.0f),
			isRotationRelative = true,
			visualDuration = duration
		},
		new SpawnVisualObject {
			textureFilePath = "Mechanics/Resources/Mark1Blue.png",
			relativePosition = new Vector3(x, 0.8f, y),
			scale = new Vector3(0.5f, 0.5f, 1.0f),
			eulerAngles = new Vector3(0f, 90f, 0f),
			isRotationRelative = true,
			visualDuration = duration
		}
	};
	return events;
}

MechanicProperties makeMouthMech(int[] targetOrder, int rotation) {
	var eventList = new List<MechanicEvent> {
		new WaitEvent {
			timeToWait = DevourData.mouthInitialPauseTime
		}
	};
	for (int i = 1; i < 7; i++) {
		int target = (targetOrder[i] + 2 * rotation) % 8;
		var location = DevourData.targetLocationsClockwise[target];
		eventList.Add(new SetEnemyMovement { position = new Vector2(location.X, location.Y), movementTime = DevourData.mouthTravelTime });
		eventList.Add(new WaitEvent { timeToWait = DevourData.mouthTravelTime + DevourData.mouthUsualPauseTime });
	}
	var finalLocation = DevourData.targetLocationsClockwise[(targetOrder[7] + 2 * rotation) % 8];
	eventList.Add(new SetEnemyMovement { position = new Vector2(finalLocation.X, finalLocation.Y), movementTime = DevourData.mouthTravelTime });
	
	eventList.Add(new WaitEvent { timeToWait = DevourData.mouthTravelTime + DevourData.mouthFinalPauseTime });
	eventList.Add(new SetEnemyVisible { visible = false });
	eventList.Add(new WaitEvent { timeToWait = float.PositiveInfinity });
	
	return new MechanicProperties {
		mechanic = new ExecuteMultipleEvents
		{
			events = eventList
		}
	};
}

MechanicProperties makeDevour(int[] targetOrder, int rotation, string mouthMechName) {
	var eventList = new List<MechanicEvent> {
		new WaitEvent { timeToWait = 2 }
	};
	for (int i = 0; i < 8; i++) {
		int target = (targetOrder[i] + 2 * rotation) % 8;
		var location = DevourData.targetLocationsClockwise[target];
		var duration = DevourData.firstAoEWaitTime + DevourData.AoEVisibleTime + i * DevourData.TimeBetweenStampedeHits;
		eventList.AddRange(makeTargetMarker(location.X, location.Y, duration));
	}
	var mouthStartingLocation = DevourData.targetLocationsClockwise[(targetOrder[0] + 2 * rotation) % 8];
	eventList.Add(new SpawnEnemy {
		enemyName = "Mouth",
		textureFilePath = "Mechanics/Resources/Teeth.png",
		baseMoveSpeed = 50,
		colorHtml = "#ff0000",
		maxHp = 10,
		isTargetable = false,
		showInEnemyList = false,
		position = new Vector2( mouthStartingLocation.X, mouthStartingLocation.Y ),
		visualPosition = new Vector3(0, 1.4f, 0),
		isPositionRelative = true,
		isRotationRelative = true,
		visualScale = new Vector3( 1f, 1f, 1f ),
		referenceMechanicName = mouthMechName
	});
	eventList.Add(new WaitEvent {
		timeToWait = DevourData.firstAoEWaitTime
	});
	for (int i = 0; i < 8; i++) {
		int target = (targetOrder[i] + 2 * rotation) % 8;
		var location = DevourData.targetLocationsClockwise[target];
		eventList.Add(new SpawnMechanicEvent {
			referenceMechanicName = "Stampede",
			position = new Vector3(location.X, location.Y),
			rotation = 0f,
			isPositionRelative = true,
			isRotationRelative = true
		});
		eventList.Add(new WaitEvent{ timeToWait = DevourData.TimeBetweenStampedeHits });
	}
	return new MechanicProperties {
		mechanic = new ExecuteMultipleEvents
		{
			events = eventList
		}
	};
}

void Main()
{
	var mechanicName = "Devour";
	var baseOutputPath = @"C:\Users\jen\Programs\XivMechanicSim";
	
	var mechanicData = new MechanicData();

	int[] circlesTargetOrder = { 1, 3, 5, 7, 4, 2, 0, 6 };
	int[] zigzagTargetOrder = { 1, 3, 0, 6, 4, 2, 5, 7 };
	
	mechanicData.referenceMechanicProperties = new Dictionary<string, MechanicProperties>
	{
		{
			"ArenaBoundarySide",
			new MechanicProperties {
				collisionShape = CollisionShape.Rectangle,
				collisionShapeParams = new Vector4(2, 14),
				colorHtml = "#8800ff",
				persistentTickInterval = 0.1f,
				persistentMechanic = new ApplyEffectToPlayers {
					effect = new DamageEffect {
						damageType = "TrueDamage",
						damageAmount = 9999999
					}
				}
			}
		},
		{
			"ArenaBoundary",
			new MechanicProperties {
				mechanic = new ExecuteMultipleEvents {
					events = new List<MechanicEvent> {
						new SpawnMechanicEvent {
							referenceMechanicName = "ArenaBoundarySide",
							position = new Vector3(0, 5),
							rotation = 0
						},
						new SpawnMechanicEvent {
							referenceMechanicName = "ArenaBoundarySide",
							position = new Vector3(5, 0),
							rotation = 90
						},
						new SpawnMechanicEvent {
							referenceMechanicName = "ArenaBoundarySide",
							position = new Vector3(0, -5),
							rotation = 180
						},
						new SpawnMechanicEvent {
							referenceMechanicName = "ArenaBoundarySide",
							position = new Vector3(-5, 0),
							rotation = 270
						}
					}
				}
			}
		},
		{
			"ArenaFloor",
			new MechanicProperties {
				mechanic = new SpawnVisualObject {
					textureFilePath = "Mechanics/Resources/ArenaCircle.png",
					relativePosition = new Vector3(0f, -0.001f, 0f),
					eulerAngles = new Vector3(90, 90, 0),
					scale = new Vector3(10, 10, 1),
					visualDuration = float.PositiveInfinity
				}
			}
		},
		{
			"Stampede",
			new MechanicProperties {
				collisionShapeParams = new Vector4(3.9f, 360),
				colorHtml = "#fff600",
				visible = true,
				mechanic = new ExecuteMultipleEvents {
					events = new List<MechanicEvent> {
						new WaitEvent { timeToWait = DevourData.AoEVisibleTime },
						new ApplyEffectToPlayers {
							effect = new DamageEffect {
								name = "Starving Stampede",
								damageType = "TrueDamage",
								damageAmount = 9999999
							}
						}
					}
				}
			}
		},
		{
			"CirclesMouth-1",
			makeMouthMech(circlesTargetOrder, 0)
		},
		{
			"Circles-1",
			makeDevour(circlesTargetOrder, 0, "CirclesMouth-1")
		},
		{
			"CirclesMouth-2",
			makeMouthMech(circlesTargetOrder, 1)
		},
		{
			"Circles-2",
			makeDevour(circlesTargetOrder, 1, "CirclesMouth-2")
		},
		{
			"CirclesMouth-3",
			makeMouthMech(circlesTargetOrder, 2)
		},
		{
			"Circles-3",
			makeDevour(circlesTargetOrder, 2, "CirclesMouth-3")
		},
		{
			"CirclesMouth-4",
			makeMouthMech(circlesTargetOrder, 3)
		},
		{
			"Circles-4",
			makeDevour(circlesTargetOrder, 3, "CirclesMouth-4")
		},
		{
			"ZigzagMouth-1",
			makeMouthMech(zigzagTargetOrder, 0)
		},
		{
			"Zigzag-1",
			makeDevour(zigzagTargetOrder, 0, "ZigzagMouth-1")
		},
		{
			"ZigzagMouth-2",
			makeMouthMech(zigzagTargetOrder, 1)
		},
		{
			"Zigzag-2",
			makeDevour(zigzagTargetOrder, 1, "ZigzagMouth-2")
		},
		{
			"ZigzagMouth-3",
			makeMouthMech(zigzagTargetOrder, 2)
		},
		{
			"Zigzag-3",
			makeDevour(zigzagTargetOrder, 2, "ZigzagMouth-3")
		},
		{
			"ZigzagMouth-4",
			makeMouthMech(zigzagTargetOrder, 3)
		},
		{
			"Zigzag-4",
			makeDevour(zigzagTargetOrder, 3, "ZigzagMouth-4")
		},
	};
	
	mechanicData.mechanicPools = new Dictionary<string, List<MechanicEvent>> {
		{
			"DevourPool",
			new List<MechanicEvent> {
				new SpawnMechanicEvent { referenceMechanicName = "Circles-1" },
				new SpawnMechanicEvent { referenceMechanicName = "Circles-2" },
				new SpawnMechanicEvent { referenceMechanicName = "Circles-3" },
				new SpawnMechanicEvent { referenceMechanicName = "Circles-4" },
				new SpawnMechanicEvent { referenceMechanicName = "Zigzag-1" },
				new SpawnMechanicEvent { referenceMechanicName = "Zigzag-2" },
				new SpawnMechanicEvent { referenceMechanicName = "Zigzag-3" },
				new SpawnMechanicEvent { referenceMechanicName = "Zigzag-4" }
			}
		}
	};
	
	mechanicData.mechanicEvents = new List<MechanicEvent>
	{
		new SpawnMechanicEvent { referenceMechanicName = "ArenaFloor", position = new Vector3(0, 0) },
		new SpawnMechanicEvent { referenceMechanicName = "ArenaBoundary", position = new Vector3(0, 0) },
		new ExecuteRandomEvents { mechanicPoolName  = "DevourPool" }
	};
	
	var resultText = mechanicData.ToString();
	
	File.WriteAllText($@"{baseOutputPath}\Mechanics\{mechanicName}.json", resultText);
	
	$"Finished writing json to Mechanics/{mechanicName}.json".Dump();
}
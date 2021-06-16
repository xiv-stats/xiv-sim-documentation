# Mechanic Events

Mechanic events are various things that a mechanic can do. This can range from damage players inside an AOE, to spawning more mechanics, to making bosses move to a certain location, etc.

### Contents  
1. [Spawning Objects](#SpawningObjects)
   - [SpawnMechanicEvent](#SpawnMechanicEvent)
   - [SpawnTargetedEvents](#SpawnTargetedEvents)
   - [SpawnTethersBetweenPlayers](#SpawnTethersBetweenPlayers)
   - [SpawnTethersToPlayers](#SpawnTethersToPlayers)
   - [SpawnVisualObject](#SpawnVisualObject)
   - [SpawnEnemy](#SpawnEnemy)
2. [General Control](#GeneralControl)
   - [WaitEvent](#WaitEvent)
   - [ExecuteMultipleEvents](#ExecuteMultipleEvents)
   - [ExecuteMultipleEventsParallel](#ExecuteMultipleEventsParallel)
   - [ClearMechanicsWithTag](#ClearMechanicsWithTag)
   - [EndMechanic](#EndMechanic)
   - [PausePersistentEvent](#PausePersistentEvent)
3. [Conditional Events](#ConditionalEvents)
   - [CheckNumberOfPlayers](#CheckNumberOfPlayers)
   - [CheckMechanicDepth](#CheckMechanicDepth)
   - [CheckMechanicTimer](#CheckMechanicTimer)
4. [Random Events](#RandomEvents)
   - [ExecuteRandomEvents](#ExecuteRandomEvents)
   - [ExecuteRandomEventSequence](#ExecuteRandomEventSequence)
   - [ReshuffleMechanicPoolIds](#ReshuffleMechanicPoolIds)
   - [ReshufflePlayerIds](#ReshufflePlayerIds)
5. [Apply Damage/Debuffs/etc](#MechanicEffectsEtc)
   - [ApplyEffectToPlayers](#ApplyEffectToPlayers)
   - [ApplyEffectToTargetOnly](#ApplyEffectToTargetOnly)
   - [ModifyMechanicEvent](#ModifyMechanicEvent)
6. [Enemy Controls](#EnemyControls)
   - [WaitForAggro](#WaitForAggro)
   - [SetEnemyMovement](#SetEnemyMovement)
   - [SetEnemyBaseSpeed](#SetEnemyBaseSpeed)
   - [StartCastBar](#StartCastBar)

## Spawning Objects <a name="SpawningObjects"/>

### SpawnMechanicEvent <a name="SpawnMechanicEvent"/>

This event will spawn a mechanic at some position and rotation.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `referenceMechanicName` | N/A | The mechanic to spawn, from the [`referenceMechanicProperties`](README.md#ReferenceMechanicProperties). |
| `position` | `(0,0)` | The position to spawn the mechanic at. |
| `rotation` | `0` | The rotation to spawn the mechanic at (degrees clockwise from north) |
| `isPositionRelative` | `false` | If the event is executed by another (parent) mechanic, then this determines whether to use the position relative to the parent or not. |
| `isRotationRelative` | `false` | This determines whether to use the rotation relative to the parent or not. |
| `resetMechanicDepth` | `false` | Mechanics by default are spawned with a depth counter that is 1 greater than the parent mechanic's depth. If this is true, it will set the depth counter of the newly spawned mechanic to 0. |

### SpawnTargetedEvents <a name="SpawnTargetedEvents"/>

This event takes a *targeting scheme* and will spawn a copy of the mechanic for each player returned by the targeting scheme.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `referenceMechanicName` | N/A | Same as [SpawnMechanicEvent](#SpawnMechanicEvent). |
| `position` | `(0,0)` | Same as [SpawnMechanicEvent](#SpawnMechanicEvent). |
| `rotation` | `0` | Same as [SpawnMechanicEvent](#SpawnMechanicEvent). |
| `isPositionRelative` | `false` | Same as [SpawnMechanicEvent](#SpawnMechanicEvent). |
| `isRotationRelative` | `false` | Same as [SpawnMechanicEvent](#SpawnMechanicEvent). |
| `resetMechanicDepth` | `false` | Same as [SpawnMechanicEvent](#SpawnMechanicEvent). |
| `targetingScheme` | N/A | A targeting scheme that specifies which players to target. |
| `spawnOnTarget` | `false` | If true, this will use the target player as the "parent" for the spawn position/rotation, rather than the parent mechanic. |

> **NOTE:** This event will set the target of the spawned mechanics to the players obtained from the targeting scheme. However, those mechanics will also need to have `isTargeted` and `followSpeed` set if you want the spawned mechanic to move/aim at the player.

> **NOTE 2:** The `spawnOnTarget` property is useful to have false in various situations. For example, if you want a set of protean waves to aim at players, all of those protean waves should originate from the same position, rather than on each player individually.

### SpawnTethersBetweenPlayers <a name="SpawnTethersBetweenPlayers"/>

### SpawnTethersToPlayers <a name="SpawnTethersToPlayers"/>

### SpawnVisualObject <a name="SpawnVisualObject"/>

### SpawnEnemy <a name="SpawnEnemy"/>


## General Control <a name="GeneralControl"/>



## Conditional Events <a name="ConditionalEvents"/>



## Random Events <a name="RandomEvents"/>



## Enemy Controls <a name="EnemyControls"/>



## Apply Damage/Debuffs/etc <a name="MechanicEffectsEtc"/>

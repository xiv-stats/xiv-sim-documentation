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
2. [General Events](#GeneralEvents)
   - [WaitEvent](#WaitEvent)
   - [ExecuteMultipleEvents](#ExecuteMultipleEvents)
   - [ExecuteMultipleEventsParallel](#ExecuteMultipleEventsParallel)
   - [EndMechanic](#EndMechanic)
   - [ClearMechanicsWithTag](#ClearMechanicsWithTag)
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

---

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

---

### SpawnTethersBetweenPlayers <a name="SpawnTethersBetweenPlayers"/>

---

### SpawnTethersToPlayers <a name="SpawnTethersToPlayers"/>

---

### SpawnVisualObject <a name="SpawnVisualObject"/>

---

### SpawnEnemy <a name="SpawnEnemy"/>


---

## General Events <a name="GeneralEvents"/>

### WaitEvent <a name="WaitEvent"/>
Waits for a certain amount of time. This is primarily used inside a [`ExecuteMultipleEvents`](#ExecuteMultipleEvents) event in order to have it pause for a certain amount of time before executing more events.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `timeToWait` | `0` | The amount of time to wait (seconds). |

> **NOTE:** When spawning an child mechanic that performs a wait event, that wait event will only affect the child. It will not cause the parent mechanic that spawned the mechanic to pause.

---

### ExecuteMultipleEvents <a name="ExecuteMultipleEvents"/>

Executes multiple events in sequence. Will wait for the current event to finish executing before proceeding to the next event. This event can be nested with itself and [`ExecuteMultipleEventsParallel`](#ExecuteMultipleEventsParallel).

| Property Name | Default Value | Description |
| --- | --- | --- |
| `events` | N/A | A list of meechanic events to execute. |

> **NOTE:** Most mechanic events will return immediately. If the mechanic list does not contain one of the following event types, then there is no significant difference between this and the parallel version:
> - [`WaitEvent`](#WaitEvent)
> - [`ExecuteMultipleEvents`](#ExecuteMultipleEvents) (itself)
> - [`ExecuteRandomEventSequence`](#ExecuteRandomEventSequence), 
> - [`WaitForAggro`](#WaitForAggro).

---

### ExecuteMultipleEventsParallel <a name="ExecuteMultipleEventsParallel"/>

Executes multiple events in parallel. Will **NOT** wait for the current event to finish executing before proceeding to the next event. This event can be nested with itself and [`ExecuteMultipleEvents`](#ExecuteMultipleEvents). A use case for this would be when you have two timelines defined, and you want to execute both timelines at the same time.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `events` | N/A | A list of meechanic events to execute. |

---

### EndMechanic <a name="EndMechanic"/>

This event will cause the mechanic to destroy itself immediately. This is usually used in persistent events to end them early (twister puddle exploding, etc).

(This event does not have any properties.)

---

### ClearMechanicsWithTag <a name="ClearMechanicsWithTag"/>

This event will cause all currently running mechanics that have the specified tag to destroy themselves immediately. This is useful for cleaning up persistent mechanics at phase transitions (removing e9s tiles/brambles, etc).

| Property Name | Default Value | Description |
| --- | --- | --- |
| `mechanicTag` | `null` | The same `mechanicTag` that is specified in the [mechanic properties](README.md#MechanicProperties). Not specifying this will cause untagged mechanics to destroy themselves. |

---

### PausePersistentEvent <a name="PausePersistentEvent"/>

Pauses a persistent event for some time. In some cases, you might have a conditional event that is constantly checked, and it will spawn a mechanic if the condition is failed. For example tiles in e9s will spawn a death square if 2 people enter it. For this case, the pause event can be used to prevent additional death squares from spawning until the initial death square expires.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `duration` | `0` | The amount of time to pause for (seconds). |

---


## Conditional Events <a name="ConditionalEvents"/>



## Random Events <a name="RandomEvents"/>



## Enemy Controls <a name="EnemyControls"/>



## Apply Damage/Debuffs/etc <a name="MechanicEffectsEtc"/>

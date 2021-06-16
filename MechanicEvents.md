# Mechanic Events

Mechanic events are various things that a mechanic can do. This can range from damaging players inside an AOE, to spawning more mechanics, to making bosses move to a certain location, etc.

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
   - [ResetMechanicTimer](#ResetMechanicTimer)
4. [Random Events](#RandomEvents)
   - [ExecuteRandomEventSequence](#ExecuteRandomEventSequence)
   - [ReshuffleMechanicPoolIds](#ReshuffleMechanicPoolIds)
   - [ReshufflePlayerIds](#ReshufflePlayerIds)
   - [ExecuteRandomEvents](#ExecuteRandomEvents)
5. [Apply Damage/Debuffs/etc](#MechanicEffectsEtc)
   - [ApplyEffectToPlayers](#ApplyEffectToPlayers)
   - [ApplyEffectToTargetOnly](#ApplyEffectToTargetOnly)
   - [ModifyMechanicEvent](#ModifyMechanicEvent)
6. [Enemy Controls](#EnemyControls)
   - [WaitForAggro](#WaitForAggro)
   - [SetEnemyMovement](#SetEnemyMovement)
   - [SetEnemyBaseSpeed](#SetEnemyBaseSpeed)
   - [StartCastBar](#StartCastBar)

# Spawning Objects <a name="SpawningObjects"/>

### SpawnMechanicEvent <a name="SpawnMechanicEvent"/>

This event will spawn a mechanic at some position and rotation.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `referenceMechanicName` | N/A | The mechanic to spawn, from the [`referenceMechanicProperties`](README.md#ReferenceMechanicProperties). |
| `position` | `(0,0)` | The position to spawn the mechanic at. |
| `rotation` | `0` | The rotation to spawn the mechanic at (degrees clockwise from north) |
| `isPositionRelative` | `false` | If the event is executed by another (parent) mechanic, then this determines whether to use the position relative to the parent or not. |
| `isRotationRelative` | `false` | This determines whether to use the rotation relative to the parent or not. |
| `resetMechanicDepth` <a name="MechanicDepth"/> | `false` | Mechanics by default are spawned with a depth counter that is 1 greater than the parent mechanic's depth. If this is true, it will set the depth counter of the newly spawned mechanic to 0. |

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

# General Events <a name="GeneralEvents"/>

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

Causes the mechanic to destroy itself immediately. This is usually used in persistent events to end them early (twister puddle exploding, etc).

(This event does not have any properties.)

---

### ClearMechanicsWithTag <a name="ClearMechanicsWithTag"/>

Causes all currently running mechanics that have the specified tag to destroy themselves immediately. This is useful for cleaning up persistent mechanics at phase transitions (removing e9s tiles/brambles, etc).

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


# Conditional Events <a name="ConditionalEvents"/>


### CheckNumberOfPlayers <a name="CheckNumberOfPlayers"/>

Checks to see if the number of players matches a certain expression, and executes an event based on the outcome.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `expressionFormat` | N/A | The expression to compare for. This is used as a format string, where the `"{0}"` in the string is replaced with the number of players who are standing in the AOE. (See notes for more details) |
| `ignoreInvincible` | `false` | If true, the condition will exclude recently revived players that have the "Invincibility" status (e9s tiles). |
| `successEvent` | `null` | An event to execute if the condition is satisfied. (If unspecified does nothing.) |
| `failEvent` | `null` | An event to execute if the condition is failed. (If unspecified does nothing.) |

> **NOTE:** As an example, an `expressionFormat` with the value `"{0} = 1"` will check if there is exactly 1 player in the AOE. The following operators are supported:
> - Comparisons: `=`, `>=`, `<=`, `>`, `<`, `<>`
> - Arithmetic: `+`, `-`, `*`, `/`, `%`
> - Boolean: `AND`, `OR`, `NOT`
> - Grouping: `(`, `)`

> **NOTE 2:** The expression must return a boolean value.
---

### CheckMechanicDepth <a name="CheckMechanicDepth"/>

Checks to see if the [mechanic depth](#MechanicDepth) value matches a certain expression, and executes an event based on the outcome. This is useful for a mechanic like exaflares, where you can have each puddle mechanic spawn itself in an offset position, but you only want to spawn a total of *x* puddles.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `expressionFormat` | N/A | Same as [CheckNumberOfPlayers](#CheckNumberOfPlayers), except `"{0}"` is replaced with the mechanic depth value. |
| `successEvent` | `null` | Same as [CheckNumberOfPlayers](#CheckNumberOfPlayers). |
| `failEvent` | `null` | Same as [CheckNumberOfPlayers](#CheckNumberOfPlayers). |

---

### CheckMechanicTimer <a name="CheckMechanicTimer"/>

Checks to see if the mechanic timer matches a certain expression, and executes an event based on the outcome. The mechanic timer stores the amount of time since the mechanic has spawned, or the time since the most recent [`ResetMechanicTimer`](#ResetMechanicTimer) done by the mechanic. One use case would be e9s tiles, where you reset the mechanic timer based on a [`CheckNumberOfPlayers`](#CheckNumberOfPlayers) event, and spawn a death square if the mechanic timer exceeds a certain value.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `expressionFormat` | N/A | Same as [CheckNumberOfPlayers](#CheckNumberOfPlayers), except `"{0}"` is replaced with the mechanic timer value. |
| `successEvent` | `null` | Same as [CheckNumberOfPlayers](#CheckNumberOfPlayers). |
| `failEvent` | `null` | Same as [CheckNumberOfPlayers](#CheckNumberOfPlayers). |

---

### ResetMechanicTimer <a name="ResetMechanicTimer"/>

Resets the mechanic timer to 0. Used in conjunction with [`CheckMechanicTimer`](#CheckMechanicTimer).

(This event does not have any properties.)

---

# Random Events <a name="RandomEvents"/>

There are many situations where you might need to target 4 random players with mechanic A, and the *other* 4 players with mechanic B. Or you want to randomly do one of mechanic A/B first, and later on, do the other mechanic.

In order to fully support these situations, each player and mechanic event has an internal randomized id which is pregenerated (and refreshed at controlled times). This way, you can have full control over how randomness works, without having to deal with storing previously generated random numbers inside variables, etc.

---

### ExecuteRandomEventSequence <a name="ExecuteRandomEventSequence"/>

Executes a specific mechanic from the specified mechanic pool. The mechanic pool is sorted by the internal randomized id.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `mechanicPoolName` | N/A | The mechanic pool used to choose a mechanic, from the [`referenceMechanicProperties`](README.md#ReferenceMechanicProperties). |
| `mechanicIndex` | `0` | An index into the pool, to pick which mechanic you want to execute. |

> **NOTE:** As an example, the above situation where you want to pick one of mechanic A/B at random first, and then the other one later can be done as follows:
>  1. Create a mechanic pool containing mechanics A/B.
>  2. Then inside your timeline, create an `ExecuteRandomEventSequence` with this pool and index 0, which will result in one of the mechanics being executed at random.
>  3. Later on, create another `ExecuteRandomEventSequence` with the same pool and index 1, which will result in the other mechanic being executed.

---

### ReshuffleMechanicPoolIds <a name="ReshuffleMechanicPoolIds"/>

Refreshes the internal random ids for a specific mechanic pool.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `mechanicPoolName` | N/A | Same as [ExecuteRandomEventSequence](#ExecuteRandomEventSequence). |

---

### ReshufflePlayerIds <a name="ReshufflePlayerIds"/>

Refreshes the internal random ids for all players (for targeting scenarios).

(This event does not have any properties.)

---

### ExecuteRandomEvents <a name="ExecuteRandomEvents"/>

A convenience event for executing a random subset of events in a specific mechanic pool. This is useful for situations like heavensfall towers, where you have 16 possible tower locations and only want to spawn 8 of them.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `mechanicPoolName` | N/A | Same as [ExecuteRandomEventSequence](#ExecuteRandomEventSequence). |
| `numberToSpawn` | `1` | How many mechanics in the pool to spawn. |

> **NOTE:** *This will ignore the internal random id and be completely random every time.*
---


# Apply Damage/Debuffs/etc <a name="MechanicEffectsEtc"/>


# Enemy Controls <a name="EnemyControls"/>

# Targeting Schemes

A **targeting scheme** is a way of specifying a list of players. For example, you can have a targeting scheme return all living players (spread AOE), or you can have a targeting scheme target the farthest/closest *x* players, and so on.

### Contents

1. [Common Targeting Logic](#TargetingLogic)
2. [Basic Targeting Schemes](#BasicTargeting)
   - [TargetExistingTarget](#TargetExistingTarget)
   - [TargetAllPlayers](#TargetAllPlayers)
   - [TargetRandomPlayers](#TargetRandomPlayers)
   - [TargetSpecificProximityPlayers](#TargetSpecificProximityPlayers)
   - [TargetNthHighestAggro](#TargetNthHighestAggro)
   - [TargetTetheredPlayers](#TargetTetheredPlayers)
   - [TargetPlayersInsideAoe](#TargetPlayersInsideAoe)
   - [UnionTargetingSchemes](#UnionTargetingSchemes)
4. [Pseudo-random Targeting](#PseudoRandomTargeting)
   - [TargetSpecificPlayerIds](#TargetSpecificPlayerIds)
   - [TargetSpecificPlayerIdsByClass](#TargetSpecificPlayerIdsByClass)



# Common Targeting Logic <a name="TargetingLogic"/>

All targeting schemes share the following logic:
1. The targeting scheme will select a subset of **all** players.
2. If some condition is specified, it will filter the list of players obtained (from step 1).
3. If the number of players is less than required after the filtering, it will use backup logic to get the remaining targets.
   - If a fallback targeting scheme is specified:
     1. A second list of players will be generated using the fallback targeting scheme, and this list will be sorted in a *random* order.
     2. The targeting scheme will cycle through this second list, and add players to the list (from step 2) until the required number is reached.
   - If a fallback targeting scheme is not specified, then the second list will be all **living** players instead.

The below properties are common to all targeting schemes, though some properties might be unused for certain targeting schemes.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `targetCondition` | `null` | A condition used to filter out targets after they have been selected initally. |
| `targetLivingOnly` | `true` | A special convenience condition to filter out dead targets that have been selected initially. |
| `fallbackTargetingScheme` | `null` | The targeting scheme to use in case all of the selected targets is filtered out by the conditions. |
| `totalTargetsNeeded` | `0` | If after filtering, there are less than this many targets remaining, it will use the fallback targeting scheme to select targets until this number is reached. |
| `manuallySetTargetsNeeded` | `false` | Certain targeting schemes will automatically set `totalTargetsNeeded` (see note below). If set to true, this will prevent them from changing it. |
| `dropExtraEvents` | `false` | If true, all fallback logic is ignored and extra events will not be spawned if there are not enough targets. |

> **NOTE:** In general, a targeting scheme that requires a list of ids will automatically set the `totalTargetsNeeded` to the length of that list.
> - [TargetSpecificProximityPlayers](#TargetSpecificProximityPlayers)
> - [TargetSpecificPlayerIds](#TargetSpecificPlayerIds)
> - [TargetSpecificPlayerIdsByClass](#TargetSpecificPlayerIdsByClass)

---

# Basic Targeting Schemes <a name="BasicTargeting"/>

### TargetExistingTarget <a name="TargetExistingTarget"/>

This will target the existing target of the mechanic. Primarily used for mechanics that spawn multiple mechanics on the same target. (Targeted Liquid Hells, etc.)

---

### TargetAllPlayers <a name="TargetAllPlayers"/>

This targeting scheme will target all players.

---

### TargetRandomPlayers <a name="TargetRandomPlayers"/>

This targeting scheme will target some random players.

| Property Name | Default Value | Description |
| --- | --- | --- |
| `numTargets` | `1` | How many players to select initially, before the filtering process is done. If set to 0, it will return all the players. |

> **NOTE:** There might be niche situations where it is useful to specify both `numTargets`, as well as a `totalTargetsNeeded`, though this is mainly kept for backwards compatibility with previous schemas. In the future, if there is no use case for this situation, this property will be deprecated/removed.

---

### TargetSpecificProximityPlayers <a name="TargetSpecificProximityPlayers"/>

Targets the nth closest/farthest players from the mechanic, using either a normal distance formula, or a wild charge distance formula.

---

### TargetNthHighestAggro <a name="TargetNthHighestAggro"/>

Targets the player with the nth highest aggro in the enemy's aggro table. (This targeting scheme can only be used in mechanics that originate from an enemy, otherwise it will return no players.)

---

### TargetTetheredPlayers <a name="TargetTetheredPlayers"/>

Targets the players that are currently tethered to the mechanic.

---

### TargetPlayersInsideAoe <a name="TargetPlayersInsideAoe"/>

Targets all players that are within the collision shape defined by the mechanic (doesn't have to actually be an AOE). This is useful for mechanics like Twintania's Liquid Hell baiting.

---

### UnionTargetingSchemes <a name="UnionTargetingSchemes"/>

Takes two targeting schemes and combines them together. Useful for combining multiple `TargetSpecificPlayerIdsbyClass` to target a light party with mechanics.

---

# Pseudo-random Targeting <a name="PseudoRandomTargeting"/>

There are many situations where you need to assign some random player mechanic A, and the remaining players mechanic B (chains/orbs in Light Rampant, etc). Each player has an internal random number, and you can target the player with the nth lowest number using the targeting schemes below. These internal random numbers do not change unless a [`ReshufflePlayerIds`](MechanicEvents.md#ReshufflePlayerIds) event happens, so you can use this to "remember" which player has received which mechanic.

### TargetSpecificPlayerIds <a name="TargetSpecificPlayerIds"/>

---

### TargetSpecificPlayerIdsByClass <a name="TargetSpecificPlayerIdsByClass"/>

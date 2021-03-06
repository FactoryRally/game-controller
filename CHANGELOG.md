## v2.16.1 (2021-04-29)

### Fix

- using windows dependent path seperator
- Added missing EventType Handling

## v2.16.0 (2021-04-29)

### Feat

- add timer start event

### Fix

- add robot ID to some events
- Removed wrong Robot

### Refactor

- spawn robots with direction of spawn field

## v2.15.1 (2021-04-29)

### Fix

- possible index out of bound exception
- change default attitude of robot to 1
- robot movements not executing

## v2.15.0 (2021-04-28)

### Fix

- crash due to new events
- Unloading mod fails

### Feat

- Add energy command

## v2.14.0 (2021-04-28)

### Fix

- **dev**: add missing imports
- **dev**: GRP `FailIfNull` executed regaedless of pipeline state
- add missing EventOportunity to ProgrammingPhase
- "random card distribution" is random now
- add preconditions to map endpoint calls
- Exponential card execution

### Refactor

- enable Mod-unloading (removes wrong `overwrite` message)
- **dev**: optimize authentication

### Feat

- **dev**: add default value for ErrorMessage (GRP)
- block actions in the wrong timeframe
- add animation delay
- enable waitig for `FetchNextEvent` operation
- implement map-repository endpoints
- Add Repeat Command

### Perf

- change PAT variation from 10-75 to 20-40
- optimize endpoint call

## v2.13.3 (2021-04-26)

### Fix

- compiling failing

## v2.13.2 (2021-04-26)

### Fix

- crash due to missing event passage (random card distrib=
- registers having wrong initial values
- crash on non full register execution
- `phase` being allways null
- **api**: add statement_id qualifier
- crash in some robot-related endpoints
- **oas**: remove wrong `required`

### Refactor

- allow default value serialization

## v2.13.1 (2021-04-25)

### Refactor

- sync production OAS
- **doc**: swagger doc

## v2.13.0 (2021-04-24)

### Feat

- add missng robot types

### Fix

- **merge**: resolve merge conflict
- chrash on robot falling out of map
- chrash on no enought spawn points
- add missing IMovement implementation
- wrong "missing impl." message
- **experimental**: not loading MovementManager
- Wrong phase order
- Register size
- MovementManager not loading

## v2.12.6 (2021-04-21)

### Fix

- **dev**: missing Interface adaption
- server hung up when creating map repo
- cards not randomly drawn
- bad indexing of robots causing chrash

## v2.12.6a2 (2021-04-21)

### Fix

- bad ending condition resulting in game error
- bad position mapping
- bad robot selection (chrash)

## v2.12.6a1 (2021-04-21)

### Fix

- robot missing type
- robots being placed wrong
- robot execution rotation

## v2.12.6a0 (2021-04-20)

### Fix

- missing game id mapping

## v2.12.5 (2021-04-20)

### Fix

- missing movement manager

## v2.12.4 (2021-04-20)

### Fix

- implement missing endpoint
- unimplemented statement exe phase
- bad id mapping

### Refactor

- randomize deck

## v2.12.3 (2021-04-20)

### Fix

- NullPtr on execution phase change

## v2.12.2 (2021-04-20)

### Fix

- NullPtr on PreExecutionPhase

## v2.12.1 (2021-04-20)

### Fix

- map loading causing crash

## v2.12.0 (2021-04-20)

### Feat

- **dev**: add `failIfNull` to GRP

### Fix

- wrong compiler hint
- map serialisation over ReST

## v2.11.0 (2021-04-20)

### Fix

- missing default location of entities
- setting registers not working
- error when map doesnt exists

### Refactor

- set time on game start

### Feat

- implement `passed-time`
- use default map by default

## v2.10.2 (2021-04-20)

### Fix

- **oas**: add missing tile-types

## v2.10.1 (2021-04-20)

### Fix

- drawing shop was done from shop

## v2.10.0 (2021-04-20)

### Fix

- GetMap game_id unusable
- **oas**: Wrong auth on commit action
- Map Serialization

### Feat

- **client**: keep up to date

### Refactor

- **dev**: Map Serialization

## v2.9.0 (2021-04-16)

### Feat

- **modding**: add event listener

### Fix

- vanilla mod wasnt adding programming cards

## v2.8.0 (2021-04-11)

### Feat

- modding🚀

## v2.8.0a1 (2021-04-10)

### Fix

- missing "OwnershipEnsurance" Constructor
- adapt startup to modular abstraction

### Feat

- add AI names
- **dev**: add PlayerID to PipelineContext
- **dev**: add abstraction layer for expansion

### Refactor

- map using 1D array with mapping

## v2.8.0a0 (2021-04-03)

### Fix

- map not empty
- shooting bug
- no access restriction on CommitAction

### Feat

- add Upgrade selection to GRP

## v2.7.0 (2021-03-01)

### Feat

- add laser shooting command
- shooting physix

## v2.6.0 (2021-03-01)

### Feat

- rotation cards
- implement robot `active` state
- internal utility methods

## v2.5.1 (2021-02-28)

### Perf

- remove active yield waiting (-98% CPU usage)

## v2.5.0 (2021-02-28)

### Refactor

- better movement event system

### Feat

- enable 'self'-leaving
- add password-protected info

## v2.4.0 (2021-02-28)

### Feat

- enable falling off the map

### Fix

- emit push event

## v2.3.0 (2021-02-28)

### Feat

- enable robots pushig each other
- base physical rules
- enable statement execution
- add missing `clearRegister` event

## v2.2.0 (2021-02-27)

### Fix

- execution cycle sharing between games
- wrong game info value

### Feat

- add game execution info to game info
- programming card shuffling

## v2.2.0b0 (2021-02-16)

### Feat

- implement RandomCardDistribution

## v2.1.0 (2021-02-16)

### Feat

- add pseudo movement
- add "DeckEmpty" Exception
- implement deck re-shuffeling
- implement `Programming Phase`

### Fix

- make waiting concurrent / thread save
- bad spelling
- crash due to too much health

### Perf

- use ID instead of object

## v2.1.0b1 (2021-02-15)

### Fix

- add currently unused Models
- welcome message not adapting to version size
- `BadEventException` chrash
- `NotImplementedException` on `ProgrammingPhase`

### Perf

- use `ImmutableSet` instead of `List`

## v2.1.0b0 (2021-02-14)

### Feat

- implement pre programming phase

### Refactor

- use more namespaces

## v2.0.0 (2021-02-12)

### Fix

- add missing phase informations

### Feat

- add all game phases
- add delay before game deletion

## v1.4.0 (2021-02-12)

### Feat

- games now store the round phase
- add empty and dummy events
- add `MapCreated` Event
- adding `DiscardUpgrade` event

### Fix

- missing leave event firing
- double stacking events

### Refactor

- inconsistency of  `GamePhaseChangedEvent`

## v1.3.0 (2021-02-08)

### Fix

- use implementation instead of interface
- stop crash on `NotImplementedException`
- restrict access to change robot register
- `entitys` -> `entities` typo in path
- wrong server warning

### Feat

- enable robot endpoints for consumers

## v1.2.1 (2021-02-07)

### Fix

- crash on legal events

## v1.2.0 (2021-02-07)

### Feat

- enable `getPlayer` and `getPlayers` for consumers

## v1.1.1 (2021-02-05)

### Fix

- missing closing bracket

## v1.1.0 (2021-02-05)

### Fix

- null ptr on entity access
- **oas**: add missing authentication

### Feat

- implement robot register endpoints
- implement map management
- implement `GetProgrammingCards`
- implement `GetProgrammingCard`
- add programming card backend

### Perf

- remove redundant check
- **oas**: replace parameters with references

### Refactor

- change Map implementation
- use GameRequestPipline

## v1.0.0 (2021-02-05)

### Refactor

- reference new client
- fix typo in AI name
- **oas**: replace inline definition with ref
- **oas**: change path of **BuyUpgrade**
- **oas**: rename ErrorMessage

### Fix

- **autogen**: Make TimeElapsed event an event
- **autogen**: replace bad admin access
- add missing `time elapsed` event type
- missing import
- adapt to new events

### Perf

- add end of game clean

### Feat

- implement end of game
- **full** upgrade shop phase implementation
- implement `getAvainableActions`
- add entity actions
- add `TimeElapsedEvent`
- add option to pass (do nothing)
- **oas**: add resusable path parameters
- refuse bad startgame
- commit buy upgrade events
- add empty ki
- add `name`, `max-players` and  `current-players` to game info
- add missing event data classes
- **events**: remove typesave endpoints

### BREAKING CHANGE

- #9

## v0.9.0 (2021-02-04)

### Fix

- bad enum references
- **autogen**: adapt ActionType according to documentation
- pat datatype

### Feat

- dissable admin authorisation for easy testing

## v0.8.2 (2021-02-03)

### Fix

- remove wrong authentication tag

## v0.8.1 (2021-02-03)

### Refactor

- remove bad testcase
- add client as submodule
- remove client code from this repo

## v0.8.0 (2021-02-02)

### Refactor

- **autogen**: replace authorisation attributes
- sync display oas

### Feat

- improve startup message
- add version to main file
- add authoriation check to all endpoints
- add programming card endpoints
- add robot and register backend
- implement `getRobots` endpoint
- implement robot register endpoints

### Fix

- bad regex

## v0.7.0 (2021-02-01)

### Feat

- implement upgrade endpoints
- add upgrade phase
- add name to game status response
- add robot ownership check

## v0.6.0 (2021-02-01)

### Feat

- add upgrade implementation

## v0.5.2 (2021-02-01)

### Fix

- empty event response

## v0.5.1 (2021-02-01)

### Fix

- consumer not passing GRP

## v0.5.0 (2021-01-31)

### Feat

- implement upgrades
- adding Upgrade manager

### Fix

- **autogen**: bad parameter mapping

## v0.4.3 (2021-01-31)

### Fix

- bad parameter mapping

## v0.4.2 (2021-01-31)

### Fix

- bad regex preventing consumer registration

## v0.4.1 (2021-01-30)

### Fix

- nullpointer for any event

## v0.4.0 (2021-01-30)

### Feat

- consumer events
- consumer pat authorisation
- consumer handling
- add consumer registration to OAS

### Fix

- player id not zero
- add response to `register consumer`
- insecure type conversion at authentication

## v0.3.0 (2021-01-26)

### Feat

- started games now "run" endlessly without exception

### Fix

- lock in (pick robot) exception
- **autogen**: empty(null) controlled entities list
- change != to ==

### Refactor

- stop forwarding GamePhaseChanged to phases

## v0.2.2 (2021-01-26)

### Fix

- empty entity manager

## v0.2.1 (2021-01-26)

### Fix

- **cz**: broken version
- notification of general events
- action phase enum conversion

### Feat

- exceptionless general phase notification
- add info to BadEventException

## v0.2.1b2 (2021-01-26)

### Fix

- NullPrt on empty password (on join)

## v0.1.2b1 (2021-01-26)

### Fix

- `GamePhaseChange` causing crash

### Feat

- disable `hardware-attached`
- enable bad event and action notifications
- implement `/v1/games/{game_id}/map`

### Refactor

- **autogen**: make EntityUseUpgradeAction an event
- adapt version in OAS

## v0.2.1b0 (2021-01-22)

### Fix

- pop -> peek
- add missing name mapping
- not returning game id after creation
- add missing auth tag
- authentication crash with invald game id
- NullPrt on event
- **autogen**: enable RobotPickEvent

### Feat

- implement robot picking/assignment

### Refactor

- change accessors
- **autogen**: replace wrongly generated attributes by extending

## v0.2.1a1 (2021-01-22)

### Fix

- fire event on join
- event-type fetching using pop instead of peek
- bad (inversed) typecheck

### Feat

- add thread event notification
- add missing events
- add player display name
- add missing event types

## v0.2.1a0 (2020-09-25)

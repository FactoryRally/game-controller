### Events & Updates
Sometimes you would like to know what the Api is doing and what changed since the last fetch. This is called events.

Detecting one or more updates includes three mayor steps:
- Waiting for the next event
- receiving the type of the event
- fetch the right event by its type

> Note that the code below is `pseudo code` in JS, means the names of the classes and functions are not the one from the api

```javascript
let wait = true; // false if you do not like to block the thread
let type = eventAPI.fetchNextEventType(game_id,wait);
if(type == EventType.MOVE_EVENT){//you could also use switch
     let moveEvent = eventAPI.fetchNextMovementEvent(game_id);
     ... 
}
```
This system is needed to provide type savety in languages such as Java and C#

if you do not like to wait you will need something like this
```javascript
let wait = false; // false if you do not like to block the thread
try{
    var type = eventAPI.fetchNextEventType(game_id,wait);
}catch(e){
    if(e.statusCode == 302){
        console.log("No Event avinable");
    }
}
if(type == EventType.MOVE_EVENT){//you could also use switch
     var moveEvent = eventAPI.fetchNextMovementEvent(game_id);
     ... 
}
```

If you use an "typeless" language like JS you can do the following

```javascript
let wait = true;
let anyEvent = eventAPI.getNextEvent(game_id,wait);
let eventType = anyEvent.type;
let eventData = anyEvent.data;
...
```

### Generic Events

Generics events are such that do not need additional information and only consist of a type. For them there are no seperate paths, you have to use `getNextEvent` to fetch them.
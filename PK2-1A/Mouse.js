document.addEventListener('click', function (event)
{
    let elem = event.target;
    let jsonObject =
    {
        Key: 'click',
        Value: elem.name || elem.id || elem.tagName || "Unkown"
    };
    window.chrome.webview.postMessage(jsonObject);


}); 
document.addEventListener('DOMContentLoaded', function () {
document.body.id="gggg";

// поддерживается ли pointerLock
var havePointerLock = 'pointerLockElement' in document ||
    'mozPointerLockElement' in document ||
    'webkitPointerLockElement' in document;

// Элемент для которого будем включать pointerLock
var requestedElement = document.getElementById('gggg');

// Танцы с префиксами
requestedElement.requestPointerLock = requestedElement.requestPointerLock ||
                                      requestedElement.mozRequestPointerLock ||
                                      requestedElement.webkitRequestPointerLock;

document.exitPointerLock =  document.exitPointerLock ||
                            document.mozExitPointerLock ||
                            document.webkitExitPointerLock;

var isLocked = function(){
  return requestedElement === document.pointerLockElement ||
         requestedElement === document.mozPointerLockElement ||
         requestedElement === document.webkitPointerLockElement;
}

requestedElement.addEventListener('click', function(){
  if(!isLocked()){
    requestedElement.requestPointerLock();
  } else {
    document.exitPointerLock();
  }
}, false);


var changeCallback = function() {
  if(!havePointerLock){
    alert('Ваш браузер не поддерживает pointer-lock');
    return;
  }
  if (isLocked()) {
    document.addEventListener("mousemove", moveCallback, false);
    document.body.classList.add('locked');
  } else {
    document.removeEventListener("mousemove", moveCallback, false);
    document.body.classList.remove('locked');
  }
}

document.addEventListener('pointerlockchange', changeCallback, false);
document.addEventListener('mozpointerlockchange', changeCallback, false);
document.addEventListener('webkitpointerlockchange', changeCallback, false);

var moveCallback = function(e) {
  var x = e.movementX ||
          e.mozMovementX ||
          e.webkitMovementX ||
          0;

  var y = e.movementY ||
          e.mozMovementY ||
          e.webkitMovementY ||
          0;

  var bgPos = window.getComputedStyle(requestedElement)
          .getPropertyValue('background-position')
          .split(' ')
          .map(function(v){
            return parseInt(v,10);
          });

  requestedElement.style.backgroundPosition = (bgPos[0] - x) + 'px ' + (bgPos[1] - y) + 'px';
}


});


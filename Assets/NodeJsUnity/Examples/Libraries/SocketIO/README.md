
<!-- saved from url=(0072)https://raw.githubusercontent.com/NetEase/UnitySocketIO/master/README.md -->
<html><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8"><style id="clearly_highlighting_css" type="text/css">/* selection */ html.clearly_highlighting_enabled ::-moz-selection { background: rgba(246, 238, 150, 0.99); } html.clearly_highlighting_enabled ::selection { background: rgba(246, 238, 150, 0.99); } /* cursor */ html.clearly_highlighting_enabled {    /* cursor and hot-spot position -- requires a default cursor, after the URL one */    cursor: url("chrome-extension://pioclpoplcdbaefihamjohnefbikjilc/clearly/images/highlight--cursor.png") 14 16, text; } /* highlight tag */ em.clearly_highlight_element {    font-style: inherit !important; font-weight: inherit !important;    background-image: url("chrome-extension://pioclpoplcdbaefihamjohnefbikjilc/clearly/images/highlight--yellow.png");    background-repeat: repeat-x; background-position: top left; background-size: 100% 100%; } /* the delete-buttons are positioned relative to this */ em.clearly_highlight_element.clearly_highlight_first { position: relative; } /* delete buttons */ em.clearly_highlight_element a.clearly_highlight_delete_element {    display: none; cursor: pointer;    padding: 0; margin: 0; line-height: 0;    position: absolute; width: 34px; height: 34px; left: -17px; top: -17px;    background-image: url("chrome-extension://pioclpoplcdbaefihamjohnefbikjilc/clearly/images/highlight--delete-sprite.png"); background-repeat: no-repeat; background-position: 0px 0px; } em.clearly_highlight_element a.clearly_highlight_delete_element:hover { background-position: -34px 0px; } /* retina */ @media (min--moz-device-pixel-ratio: 2), (-webkit-min-device-pixel-ratio: 2), (min-device-pixel-ratio: 2) {    em.clearly_highlight_element { background-image: url("chrome-extension://pioclpoplcdbaefihamjohnefbikjilc/clearly/images/highlight--yellow@2x.png"); }    em.clearly_highlight_element a.clearly_highlight_delete_element { background-image: url("chrome-extension://pioclpoplcdbaefihamjohnefbikjilc/clearly/images/highlight--delete-sprite@2x.png"); background-size: 68px 34px; } } </style><style type="text/css" id="eow_sv_style">#sideView_wrapper {
height: 400px;
width: 500px;
border-top: 1px solid #999 !important;
border-left: 1px solid #999 !important;
box-shadow: -1px 2px 2px rgba(0,0,0,0.3) !important;
position: fixed !important;
right: 0px !important;
bottom: 0px !important;
z-index: 2147483646;
}
#sideView_ifr {
border: none !important;
height: 100%;
width: 100%;
}#sideView_wrapper {
position: fixed !important;
left: auto !important;
right: 0px !important;
top: auto !important;
bottom: 0px !important;
}
#sideView_wrapper .ui-resizable-nw {
background-image: url("chrome-extension://oonalfdoahlmjaoloddjenihohbfodme/img/resize-grip-nw.png") !important;
background-repeat: no-repeat !important;
cursor: nw-resize !important;
width: 20px !important;
height: 20px !important;
position: absolute !important;
top: 0px !important;
left: 0px !important;
}sideView_icons
{
padding: 0 !important;
margin: 0 !important;
border-style: none !important;
z-index: 1002 !important
}#pun_ui {
width: 24px;
height: 24px;
position: absolute !important;
left: 7px !important;
top: -2px !important;
z-index: 1005;
}
#pun_ui[ison="true"] {
background-image: url("chrome-extension://oonalfdoahlmjaoloddjenihohbfodme/img/pin_on.png") !important;
}
#pun_ui[ison="false"] {
background-image: url("chrome-extension://oonalfdoahlmjaoloddjenihohbfodme/img/pin_off.png") !important;
}#toggle_header {
width: 24px;
height: 24px;
position: absolute !important;
left: 33px !important;
top: 0px !important;
}
#toggle_header[ison="true"] {
background-image: url("chrome-extension://oonalfdoahlmjaoloddjenihohbfodme/img/openheader.png") !important;
}
#toggle_header[ison="false"] {
background-image: url("chrome-extension://oonalfdoahlmjaoloddjenihohbfodme/img/hideheader.png") !important;
z-index: 1005;
}</style><style>[touch-action="none"]{ -ms-touch-action: none; touch-action: none; }[touch-action="pan-x"]{ -ms-touch-action: pan-x; touch-action: pan-x; }[touch-action="pan-y"]{ -ms-touch-action: pan-y; touch-action: pan-y; }[touch-action="scroll"],[touch-action="pan-x pan-y"],[touch-action="pan-y pan-x"]{ -ms-touch-action: pan-x pan-y; touch-action: pan-x pan-y; }</style></head><body data-pinterest-extension-installed="cr1.3.1"><pre style="word-wrap: break-word; white-space: pre-wrap;">UnitySocketIO
=============================
The  project is the socket.io client for unity3d, written in C#.
It's based on socketio4net.Client (http://socketio4net.codeplex.com/). However, 
socketio4net.Client only provides a .NET 4.0 C# client, and does compatible with unity3d. 
We've done a lot of works on supporting unity3d.

The project was initially designed for unity client of [pomelo](https://github.com/NetEase/pomelo) 
framework, which is a powerful, scalable game server framework.

## How to use

It is very simple to use UnitySocketIO. Copy all the DLLS locating in the file of /bin/Debug/  to your project.

Of course, you can download this project and compile it:

&gt;git clone  https://github.com/NetEase/UnitySocketIO.git

## API

Create and initialize a new UnitySocketIO client.

```c#
Client client = new Client(url);

client.Opened += SocketOpened;
client.Message += SocketMessage;
client.SocketConnectionClosed += SocketConnectionClosed;
client.Error +=SocketError;

client.Connect();

private void SocketOpened(object sender, MessageEventArgs e) {
    //invoke when socket opened
}

```
Send message to server.

```c#

client.Send(messge);

```
Get message from server.

```c#
private void SocketMessage (object sender, MessageEventArgs e) {
    if ( e!= null &amp;&amp; e.Message.Event == "message") {
        string msg = e.Message.MessageText;
       process(msg);
    }
}

```
Close connection.

```c#

client.Close();

```


##License
(The MIT License)

Copyright (c) 2012-2013 NetEase, Inc. and other contributors

Permission is hereby granted, free of charge, to any person obtaining a 
copy of this software and associated documentation files (the 'Software'), 
to deal in the Software without restriction, including without limitation
the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in 
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

</pre><span style="height: 20px; width: 40px; min-height: 20px; min-width: 40px; position: absolute; opacity: 0.85; z-index: 8675309; display: none; cursor: pointer; background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACgAAAAUCAMAAADImI+JAAABa1BMVEWfn5ugoJuqqqqhoZqfn5qeoZygoJr19fXt7e2tABitABry8vLs7Ozx8fGfn5utABytCyL5+fn39/fo6Ojv7+/n5+euDCLQlJitABnRhIm/Vl65OUTf393kzdDd3d3FxsPWmZytAB6uFietAB+vGCnn0NPQg4ivFyjhy8u4N0O7u7e8SlLm5ub6+vr+/v77+/vl5eXu4OCvDyT16euvESW0JTOxGivp09WuBh/YjpPMZW67OETHbHK0LTjXjZLRg4jSg4m1KTazLDj18vLn0NH39/Xh4eGxGizHWWPUjZPpw8e7NkOvEyXGanDkztDBRFDSiY/HaXHCWWHNfIKzJDLkzM6uCCDerrTLgIPbsrTAWF/z7vHSho2tDCKsABrMeYGzKze1N0K/V17pzdC7QEu7PUjRjZPm2tvcrK/BUFrKe4KxIS/fy8usABncvr7p1tndxcW9T1iuFii5OESwHy7BSVPBWWC7SFDi4uJ7hAPQAAAAB3RSTlPtkQbukIiJwuS69QAAATJJREFUeF6N01NzBEEUhuFeJI3h2jZi27Zt2/j5Od1JTeVqZ56LmfNVvbeN7DakmnLY7MiZwI2mJhJ1CEFnDiOkNlmiIrXBEghd3OzcfKZ1qc1lCPlDrv8gdIOe4OZHb1+wfY8PFoGPP+R3VypuA4QYdHeOtZzhQTrNB4tgnC/oeTxACzDvujCAUAJ0+ImlJCnVwQd7fdOonoPrk+WkL9rPCwgVQPeH6JSiaCN8MKqNJhVhXEmytLgg9AL9YovOeK/pDR+s5DUsMG1RDAgJWF5ZpWtknW3wwd4JiW3vELJb0mg6RgQIZSF7kMkeHonzmHInssyofir/gdAjBM+Ll1eeX4Fw+DbA/0WPAUIfd//w6KsJwir3/FKtDcJmS1SEot8WRBFyluOTpuLlengKDktP4QctQnPnQ5vVrgAAAABJRU5ErkJggg==);"></span></body></html>
var util   = require('util');
var osc    = require('node-osc');
var client = new osc.Client('127.0.0.1', 6666);
var cnt    = 0;
var freq   = 60;

setInterval(function() {
	var x = Math.sin(cnt / freq * Math.PI);
	var y = Math.cos(cnt / freq * Math.PI);
	var z = 0;
	var pos = util.format('%s,%s,%s', x, y, z);
	client.send('NodeJs/Test', pos);
	console.log(pos);
	console.log("hogehoge", cnt);
	++cnt;
}, 1000/60);

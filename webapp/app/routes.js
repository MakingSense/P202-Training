var system = require('durandal/system');

module.exports = [
	// Here we define our routes as usual, but with one important distinction.
	// Our `moduleId` is no longer a string that points to the module, but rather 
	// the module itself, as an inline, static dependency. This will bundle the
	// modules into your main app, but still work as expected in Durandal!
	{
		route: '', 
		title: 'Home',
		moduleId: function() {
			return require('viewModels/home/home');
		},
		nav: true
	},
	{
		route: 'echo', 
		title: 'Echo',
		moduleId: function() {
			return require('viewModels/echo/echo');
		},
		nav: true
	}
];

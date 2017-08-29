var ko = require('knockout');
var app = require('durandal/app');
var system = require('durandal/system');

// Durandal core overrides - Required for Webpack
require('overrides/system');
require('overrides/composition');
require('overrides/views');

// Webpack sets this __DEV__ variable. See `webpack.config.js` file
if(__DEV__) {
	system.debug(true);

	window.ko = ko;
	window.app = app;
	window.router = router;
}

// Install the router
var router = require('plugins/router');
router.install({});


// Start the appliction
app.start().then(function () {
	// Set the title
	app.title = 'P202 training';

	// Show the app by setting the root view model for our application with a transition.
	var shell = require('./shell');
	return app.setRoot(shell);
});

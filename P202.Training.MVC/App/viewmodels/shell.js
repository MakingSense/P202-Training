define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function() {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', title: 'Welcome', moduleId: 'viewmodels/welcome', nav: true },
                { route: 'roleList', title: 'Role List', moduleId: 'viewmodels/role/roleList', nav: true },
                { route: 'userList', title: 'User List', moduleId: 'viewmodels/user/userList', nav: true },
                { route: 'echo', title: 'Echo', moduleId: 'viewmodels/echo/echo', nav: true },
                { route: 'flickr', moduleId: 'viewmodels/flickr', nav: true }
            ]).buildNavigationModel();
            
            return router.activate();
        }
    };
});
namespace DevStation {
    
    angular.module('DevStation', ['ngRoute', 'ui.bootstrap']);

    angular.module('DevStation').factory('authInterceptor',
        ($q: ng.IQService, $window: ng.IWindowService, $location: ng.ILocationService) => {
            return {
                request: (config) => {
                    config.headers = config.headers || {};
                    let token = $window.localStorage.getItem('token');
                    if (token) {
                        config.headers.Authorization = `Bearer ${token}`;
                    }
                    return config;
                },
                responseError: (response) => {
                    if (response.status === 401) {
                        $location.path('/login');
                    }
                    return response || $q.when(response);
                }
            };
        });

    angular.module('DevStation')
        .config(function ($routeProvider: ng.route.IRouteProvider, $httpProvider: ng.IHttpProvider) {

            $httpProvider.interceptors.push('authInterceptor');
            $routeProvider
                .when('/', {
                    templateUrl: 'Presentation/ngApp/views/homePage.html',
                    controller: DevStation.Controllers.HomePageController,
                    controllerAs: 'c'
                })
                .when("/devhome", {
                    templateUrl: "Presentation/ngApp/views/devHome.html",
                    controller: DevStation.Controllers.JobSearchController,
                    controllerAs: "c"
                })
                .when('/register',
                {
                    templateUrl: 'Presentation/ngApp/views/register.html',
                    controller: DevStation.Controllers.AuthController,
                    controllerAs: 'c'
                })
                .when('/login',
                {
                    templateUrl: 'Presentation/ngApp/views/login.html',
                    controller: DevStation.Controllers.AuthController,
                    controllerAs: 'c'
                })
                .when("/job/details/:id",
                {
                    templateUrl: "Presentation/ngApp/views/jobDetails.html",
                    controller: DevStation.Controllers.JobDetailsController,
                    controllerAs: "c"
                })
                .when("/user/devprofile", 
                {
                    templateUrl: "Presentation/ngApp/views/devProfile.html",
                    controller: DevStation.Controllers.ProfileController,
                    controllerAs: "c"
                })
                .when("/user/devprofile/edit",
                {
                    templateUrl: "Presentation/ngApp/views/devProfileEdit.html",
                    controller: DevStation.Controllers.ProfileController,
                    controllerAs: "c"
                })
                .when("/employerhome",
                {
                    templateUrl: "Presentation/ngApp/views/employerHome.html",
                    controller: DevStation.Controllers.DevSearchController,
                    controllerAs: "c"
                })


        });
}
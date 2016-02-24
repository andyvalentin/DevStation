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
                        $location.path('/');
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
                    controller: DevStation.Controllers.ModalController,
                    controllerAs: 'c'
                })
                .when("/dev/home", {
                    templateUrl: "Presentation/ngApp/views/devHome.html",
                    controller: DevStation.Controllers.JobSearchController,
                    controllerAs: "c"
                })
                .when("/job/details/:id",
                {
                    templateUrl: "Presentation/ngApp/views/jobDetails.html",
                    controller: DevStation.Controllers.JobDetailsController,
                    controllerAs: "c"
                })
                .when("/dev/profile",
                {
                    templateUrl: "Presentation/ngApp/views/devProfile.html",
                    controller: DevStation.Controllers.ProfileController,
                    controllerAs: "c"
                })
                .when("/employer/home",
                {
                    templateUrl: "Presentation/ngApp/views/employerHome.html",
                    controller: DevStation.Controllers.DevSearchController,
                    controllerAs: "c"
                })
                .when("/employer/profile", {
                    templateUrl: "Presentation/ngApp/views/employerProfile.html",
                    controller: DevStation.Controllers.EmployerProfileController,
                    controllerAs: "c"
                })
                .when("/dev/inbox", {
                    templateUrl: "Presentation/ngApp/views/devinbox.html",
                    controller: DevStation.Controllers.InboxController,
                    controllerAs: "c"
                })
                .when("/employer/inbox", {
                    templateUrl: "Presentation/ngApp/views/employerinbox.html",
                    controller: DevStation.Controllers.InboxController,
                    controllerAs: "c"
                })
        });
}
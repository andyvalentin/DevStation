namespace DevStation.Controllers {
    export class HomePageController {

        public registration() {
            this.$uibModal.open({
                templateUrl: 'Presentation/ngApp/views/register.html',
                controller: DevStation.Controllers.AuthController,
                controllerAs: 'c'
            });
        }

        public login() {
            this.$uibModal.open({
                templateUrl: 'Presentation/ngApp/views/login.html',
                controller: DevStation.Controllers.AuthController,
                controllerAs: 'c'
            });
        }

        constructor(private $uibModal) { }

    }

    angular.module('DevStation').controller('HomePageController', HomePageController)
}
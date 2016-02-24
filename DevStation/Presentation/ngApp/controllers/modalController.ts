namespace DevStation.Controllers {
    export class ModalController {

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
}
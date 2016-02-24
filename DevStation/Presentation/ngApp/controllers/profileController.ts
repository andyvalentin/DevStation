namespace DevStation.Controllers {

    export class ProfileController {
        public user;
        public employer;

        public toEdit() {
            this.$uibModal.open({
                templateUrl: 'Presentation/ngApp/views/devProfileEdit.html',
                controller: DevStation.Controllers.ProfileController,
                controllerAs: 'c'
            });
        }

        public updateDevProfile() {
            this.$http.post("api/user/profile/edit", this.user)
                .then((response) => {
                })
            location.reload();
        }


        public getUserProfile() {
            this.$http.get("api/users/profile")
                .then((reponse) => {
                    this.user = reponse.data;
                });
        }

        public getEmployerProfile() {
            this.$http.get(`/api/users/employerProfile`)
                .then((response) => {
                    this.employer = response.data;
                })
        }

        public finishJob(id) {
            this.$http.get(`api/users/completeJob/${id}`)
                .then((response) => {
                    this.getUserProfile();
                })
        }

        public jobDetails(id: number) {
            this.$location.path(`/job/details/${id}`);
        }

        public logout() {
            this.$window.localStorage.removeItem('token');
        }

        constructor(private $http: ng.IHttpService, private $window: ng.IWindowService, private $location: ng.ILocationService, private $uibModal) {
            this.getUserProfile();
            this.getEmployerProfile();
        }

    }
}
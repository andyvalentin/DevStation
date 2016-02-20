namespace DevStation.Controllers {

    export class ProfileController {
        public user;
        public employer;

        public toEdit() {
            this.$location.path("/devprofile/edit");
        }

        public updateDevProfile() {
            this.$http.post("api/user/profile/edit", this.user)
                .then((response) => {
                })
            console.log("Function works");
            this.$location.path("/user/devprofile/");
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

        public logout() {
            this.$window.localStorage.removeItem('token');
            this.$location.path("/");
        }

        public finishJob(id) {
            this.$http.get(`api/users/completeJob/${id}`)
                .then((response) => {
                    
                })
        }

        constructor(private $http: ng.IHttpService, private $window: ng.IWindowService, private $location: ng.ILocationService) {
            this.getUserProfile();
            this.getEmployerProfile();
        }

    }
}
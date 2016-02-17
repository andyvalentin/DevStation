namespace DevStation.Controllers {

    export class ProfileController {
        public user;

        public toEdit() {
            this.$location.path("/user/devprofile/edit");
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

        public logout() {
            this.$window.localStorage.removeItem('token');
            this.$location.path("/");
        }

        constructor(private $http: ng.IHttpService, private $window: ng.IWindowService, private $location: ng.ILocationService) {
            this.getUserProfile();
        }

    }
}
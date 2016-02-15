namespace DevStation.Controllers {

    export class ProfileEditController {
        public user;

        public updateDevProfile() {
            this.$http.post("api/user/profile/edit", this.user)
                .then((response) => {
                })
            console.log("Function works");
            this.$location.path("/user/profile/");
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
namespace DevStation.Controllers {
    export class ProfileController {
        public user;

        public constructor(private $http: ng.IHttpService, private $location: ng.ILocationService) {
            this.$http.get(`/api/users/profile`)
                .then((response) => {
                    this.user = response.data;
                })
        }
    }
}
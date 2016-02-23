namespace DevStation.Controllers {
    export class JobDetailsController {
        public job;

        public acceptJob() {
            this.$http.post("api/dev/acceptjob", this.job)
                .then((response) => {
                    this.$location.path("/dev/home")
                });
        }

        public logout() {
            this.$window.localStorage.removeItem('token');
        }

        constructor(private $http: ng.IHttpService, $routeParams, private $location: ng.ILocationService, private $window) {
            $http.get(`/api/jobs/${$routeParams["id"]}`)
                .then((response) => {
                    this.job = response.data;
            })
        }
    }
}
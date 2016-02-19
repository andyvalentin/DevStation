namespace DevStation.Controllers {
    export class AddJobsController {
        public job;

        public addJob() {
            this.$http.post(`/api/jobs/add`, this.job)
                .then((response) => {
                    this.$location.path("/employerprofile");
                })
        }

        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService) {
            
        }
    }
}
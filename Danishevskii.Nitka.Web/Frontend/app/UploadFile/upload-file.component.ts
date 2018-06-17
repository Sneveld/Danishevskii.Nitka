import { Output, Component, EventEmitter } from '@angular/core';
import { FilesService } from './files.service';

@Component({
    selector: 'upload-file',
    templateUrl: './file.html',
    providers: [FilesService]
})
export class UploadFileComponent {
    @Output() dataLoadedEvent = new EventEmitter();

    loading: boolean = false;

    constructor(private fileService: FilesService) {

    }

    upload(files: FileList) {
        this.loading = true;
        const file = files.item(0);
        this.fileService.upload(file).subscribe(
            res => {
                this.dataLoadedEvent.emit();
                this.loading = false;
            },
            error => { this.loading = false;}
        );
    }
}
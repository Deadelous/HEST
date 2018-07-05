import { Pipe, PipeTransform } from '@angular/core';
import { isObject } from "rxjs/util/isObject";
import { isEmpty } from "rxjs/operator/isEmpty";
import { empty } from "rxjs/Observer";

@Pipe({
    name: 'search',
})
export class MovieSearchPipe implements PipeTransform {
    transform(input, searchString) {
        if (input == null) return input;
        return input.filter(this.compareWithAllFields, searchString);
    }

    compareWithAllFields(value, index) {
        var fields = Object.keys(value);
        for (let i = 0; i < fields.length; i++) {
            if (value[fields[i]] != null) {
                if (isObject(value[fields[i]])) {
                    var childFields = Object.keys(value[fields[i]]);
                    if (childFields.length > 0) {
                        for (let j = 0; j < childFields.length; j++) {
                            if ((value[fields[i]][childFields[j]] + "").toLowerCase().indexOf(this.toString().toLowerCase()) !== -1) {
                                return true;
                            }
                        }
                    }
                }
                if ((value[fields[i]] + "").toLowerCase().indexOf(this.toString().toLowerCase()) !== -1) {
                    return true;
                }
            }
        }
        return false;
    }
}

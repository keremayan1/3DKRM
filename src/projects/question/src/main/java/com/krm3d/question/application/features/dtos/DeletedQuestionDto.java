package com.krm3d.question.application.features.dtos;

import lombok.Data;
import org.springframework.data.annotation.Id;

@Data
public class DeletedQuestionDto {
    @Id
    private String id;
}
